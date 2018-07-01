using BlackFireFramework;
using BlackFireServer.Server.Business;
using System;

namespace BlackFireServer.Server
{
    internal static class App
    {

        static void Main(string[] args)
        {

            InitServer(args);
            InitFramework();

        }










        private static void InitServer(string[] args)
        {
            BusinessApp.Run(args);
        }

        private static readonly object s_God = new object();
        private static float s_RealElapsedDeltaTime = 0.02f;
        private static float s_VirsulElapsedDeltaTime;
        private static void InitFramework()
        {
            TimeSpan timeSpan;
            DateTime dateTime;
            var realElapsedDeltaTime = (int)(s_RealElapsedDeltaTime * 1000);
            Framework.Born(s_God, s_RealElapsedDeltaTime, s_VirsulElapsedDeltaTime);
            StartAssemblyManager();
            while (true)
            {
                dateTime = DateTime.Now;
                System.Threading.Thread.Sleep(realElapsedDeltaTime);
                timeSpan = DateTime.Now - dateTime;
                s_VirsulElapsedDeltaTime = timeSpan.Milliseconds / 1000f;
                Framework.Act(s_God, s_RealElapsedDeltaTime, s_VirsulElapsedDeltaTime);
                //if (!Framework.State.Working) break;
            }
            //ShutdownAssemblyManager();
            //Framework.Die(s_God,s_RealElapsedDeltaTime,s_VirsulElapsedDeltaTime);
        }

        #region ExportedAssembly

        private static string[] m_AssemblyList = new string[] { "BlackFireServer.GameLogic" };

        private static IExportedAssemblyManager m_ExportedAssemblyManager = null;

        private static void StartAssemblyManager()
        {
            m_ExportedAssemblyManager = (IExportedAssemblyManager)EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager));
            for (int i = 0; i < m_AssemblyList.Length; i++)
            {
                m_ExportedAssemblyManager.LoadExportedAssembly(m_AssemblyList[i]);
            }
        }

        private static void ShutdownAssemblyManager()
        {
            for (int i = 0; i < m_AssemblyList.Length; i++)
            {
                m_ExportedAssemblyManager.UnLoadExportAssembly(m_AssemblyList[i]);
            }
        }

        #endregion

    }
}
