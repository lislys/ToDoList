using Nancy;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Test
{
    internal class Bootstrapper : DefaultNancyBootstrapper
    {
        public Bootstrapper()
        {
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            //container.Register<>()
        }
    }
}
