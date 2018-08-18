using System;
using System.IO;
using System.Text;

namespace MEH2
{
    //  _                                   ____ _                
    // | |    ___   __ _  __ _  ___ _ __   / ___| | __ _ ___ ___  
    // | |   / _ \ / _` |/ _` |/ _ \ '__| | |   | |/ _` / __/ __| 
    // | |__| (_) | (_| | (_| |  __/ |    | |___| | (_| \__ \__ \ 
    // |_____\___/ \__, |\__, |\___|_|     \____|_|\__,_|___/___/ 
    //             |___/ |___/                                    

    //https://stackoverflow.com/a/11262480
    class ThreadsafeOutputWriter : IDisposable
    {
        private FileStream file; //Only this instance have a right to own it
        private StreamWriter writer;
        private object CriticalSelection; //Mutex for synchronizing

        public ThreadsafeOutputWriter(string logPath, Encoding encoding)
        {
            file = new FileStream(logPath, FileMode.Create, FileAccess.Write, FileShare.Read);
            writer = new StreamWriter(file, encoding);
            CriticalSelection = new object();
        }

        // Log is thread safe, it can be called from many threads
        public void WriteString(string message)
        {
            lock (CriticalSelection)
            {
                writer.WriteLine(message);
            }
        }

        public void Dispose()
        {
            writer.Dispose(); //Will close underlying stream
        }
    }
}
