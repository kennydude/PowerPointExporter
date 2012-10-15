using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Packaging;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Interop.Publisher;
using System.Diagnostics;
using System.Drawing;

namespace PowerPointExporter
{
    public class ExportJob
    {
        public String method = "";
        public String file = "";
        public String options = "";
        ExportingDialog ed;
            
        public void run(Form f)
        {
            ed = new ExportingDialog();
            ed.job = this;
            ed.Show(f);
        }

        String getTempDir()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }

        Microsoft.Office.Interop.PowerPoint.Application openPowerPoint()
        {
            Microsoft.Office.Interop.PowerPoint.Application powerPoint = new Microsoft.Office.Interop.PowerPoint.Application();
            foreach (Presentation ppt in powerPoint.Presentations)
            {
                ppt.Close();
            }
            powerPoint.Presentations.Open(file);
            return powerPoint;
        }

        public void runInForm()
        {
            ed.addDebug("Exporting " + file + "...");
            String tempDir = getTempDir();
            ed.addDebug("Tempoary Directory: " + tempDir);

            if (this.method == "handouts")
            {
                Package zipPresentation = null;
                if (options.Contains("exportNotes"))
                {
                    String tmpFile = Path.Combine(tempDir, "pres.zip");
                    File.Copy(file, tmpFile);
                    zipPresentation = ZipPackage.Open(new FileStream(tmpFile, FileMode.Open));
                }

                Microsoft.Office.Interop.PowerPoint.Application powerPoint = openPowerPoint();
                ed.addDebug("PowerPoint should have loaded document");
                ed.addDebug("Exporting as handouts...");
                Presentation toExport = powerPoint.Presentations[1];

                ed.addDebug("Opening Publisher Template");
                Microsoft.Office.Interop.Publisher.Application publisher = new Microsoft.Office.Interop.Publisher.Application();

                String pubFile = Path.Combine(tempDir, "out.pub");
                File.Copy(Path.Combine(
                    Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath),
                    "Templates",
                    "Handout-3P.pub" // TODO: Add option for different templates
                ), pubFile);
                Document publisherDoc = publisher.Open( pubFile );
                publisher.ActiveWindow.Visible = true;


                int slideWidth = (int) toExport.PageSetup.SlideWidth;
                int slideHeight = (int)toExport.PageSetup.SlideHeight;
                int slideCount = 1, onPage = 1;
                publisherDoc.Pages[onPage].Duplicate();

                foreach(_Slide slide in toExport.Slides){
                    if (slideCount == 4)  // End of Page but only create a new one, if there is more!
                    {
                        publisherDoc.Pages[onPage + 1].Duplicate();
                        onPage += 1;
                        slideCount = 1;
                    }

                    ed.addDebug("Exporting slide #" + slide.SlideNumber);
                    String fname = Path.Combine(tempDir, slide.SlideNumber + "-ppt.png");
                    slide.Export(fname, "png");

                    String notes = "";
                    if (options.Contains("exportNotes"))
                    {
                        // I HATE YOU POWERPOINT!
                        Uri partUriResource = PackUriHelper.CreatePartUri(
                              new Uri(@"ppt/notesSlides/notesSlide" + slide.SlideNumber + ".xml", UriKind.Relative));
                        if (zipPresentation.PartExists(partUriResource))
                        {
                            Stream noteStream = zipPresentation.GetPart(partUriResource).GetStream(FileMode.Open, FileAccess.Read);
                            StreamReader nSR = new StreamReader(noteStream);

                            // Strip crap
                            notes = nSR.ReadToEnd();
                            // Chop out slide numbers. I don't have a clue really :')
                            int s = notes.IndexOf("<p:txBody>");
                            if (s != -1)
                            {
                                notes = notes.Substring(s, notes.IndexOf("</p:txBody>") - s);
                                notes = (new Regex("<[^>]*>")).Replace(notes, "");
                            }

                            nSR.Close();
                            noteStream.Close();
                        }
                    }
                    
                    
                    foreach (Microsoft.Office.Interop.Publisher.Shape shape in publisherDoc.Pages[onPage].Shapes)
                    {
                        if (shapeHasTag(shape, "Picture "+ slideCount))
                        {
                            shape.Fill.UserPicture(fname);
                        }
                        else if (shapeHasTag(shape, "Text " + slideCount))
                        {
                            shape.TextFrame.AutoFitText = PbTextAutoFitType.pbTextAutoFitBestFit;
                            shape.TextFrame.TextRange.Text = notes;
                        }
                    }
                    
                    slideCount += 1;
                }

                publisherDoc.Pages[publisherDoc.Pages.Count].Delete();
                toExport.Close();
                ed.addDebug("Exported as handouts :)");
            }
            ed.finishJob("");
        }

        private bool shapeHasTag(Microsoft.Office.Interop.Publisher.Shape s, string p)
        {
            foreach (Tag t in s.Tags)
            {
                if (t.Name == "PPE" && t.Value == p)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
