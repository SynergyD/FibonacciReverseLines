using System;
using System.IO;
using ReverseFibonacciLines.Models.Interfaces;
using ReverseFibonacciLines.UI;
using ReverseFibonacciLines.UI.Interfaces;

namespace ReverseFibonacciLines
{
    public class ReverseFibonacciLinesApp : IReverseFibonacciLinesApp
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IFileWorker fileWorker;
        private readonly IUserInterface ui;

        public ReverseFibonacciLinesApp(IFileWorker fileWorker, IUserInterface ui)
        {
            this.fileWorker = fileWorker;
            this.ui = ui;
        }

        public void Run(string sourcePath)
        {
            try
            {
                var linesFromFile = fileWorker.GetFibonacciLines(sourcePath);
                fileWorker.FillFileByReverseLines(linesFromFile);
                ui.DisplayMessage(TextMessages.CHECKRESULT);
            }
            catch (FileNotFoundException e)
            {
                log.Error(e);
                ui.DisplayMessage(TextMessages.NOTFOUND);
                ui.DisplayMessage(TextMessages.INSTRUCTION);
            }
            catch (ArgumentNullException e)
            {
                log.Error(e);
                ui.DisplayMessage(TextMessages.EMPTY);
                ui.DisplayMessage(TextMessages.INSTRUCTION);
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        public void Error()
        {
            ui.DisplayMessage(TextMessages.INSTRUCTION);
        }
    }
}