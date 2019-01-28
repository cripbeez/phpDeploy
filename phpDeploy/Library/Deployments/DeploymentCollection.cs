using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace phpDeploy.Library.Deployments
{
    public class DeploymentCollection : IEnumerable<Deployment>
    {

        private List<Deployment> Deployments;

        public DeploymentCollection(List<Deployment> deployments = null)
        {
            this.Deployments = deployments ?? new List<Deployment>();
        }

        public Deployment this[string name]
        {
            get
            {
                return this.Deployments.Where((d) => d.Name == name).First() ?? null;
            }
        }
        public Deployment this[int i]
        {
            get
            {
                return this.Deployments[i] ?? null;
            }
        }

        public int CurrentlyRunning
        {
            get
            {
                int amount = 0;

                foreach (Deployment deployment in this)
                    if (deployment.Running)
                        amount += 1;

                return amount;
            }
        }
        public int NotRunning
        {
            get
            {
                int amount = 0;

                foreach (Deployment deployment in this)
                    if (!deployment.Running)
                        amount += 1;

                return amount;
            }
        }
        public int Count
        {
            get
            {
                return this.Deployments.Count;
            }
        }

        public void StopAll()
        {
            foreach (var deployment in this)
                deployment.Stop();
        }
        public void RestartAll()
        {
            foreach (var deployment in this)
                deployment.Restart();
        }
        public void StartAll()
        {
            foreach (var deployment in this)
                deployment.Start();
        }

        public IEnumerator<Deployment> GetEnumerator()
        {
            return ((IEnumerable<Deployment>)Deployments).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Deployment>)Deployments).GetEnumerator();
        }

        public void Create(string name, string listenStr, string attributes, string workingDir)
        {
            Deployment depl = Deployment.Create(name, listenStr, attributes, workingDir);

            if (!depl.Valid)
                return;

            this.Deployments.Add(depl);
        }

        public static DeploymentCollection DeployDirectory(string dirPath)
        {
            List<Deployment> deployments = new List<Deployment>();

            IEnumerable<string> dirInfo = Directory.EnumerateDirectories(dirPath);
            foreach (string dir in dirInfo)
            {
                string fileName = $"{dir}\\phpDeploy.xml";

                if (!File.Exists(fileName))
                    continue;

                Deployment deployment = new Deployment(fileName);

                if (!deployment.Valid)
                    continue;

                deployment.Id = deployments.Count;
                deployments.Add(deployment);
            }

            return new DeploymentCollection(deployments);
        }
    }
}
