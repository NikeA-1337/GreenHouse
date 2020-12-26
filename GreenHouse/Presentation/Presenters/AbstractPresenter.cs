using Model;
using Ninject;
using Presentation.Forms;

namespace Presentation.Presenter
{
    public abstract class AbstractPresenter<T> where T : IView
    {
        protected IKernel _kernel { get; set; }
        protected IServiceFactory _serviceFactory { get; set; }
        protected T _view { get; set; }

        public void Run()
        {
            _view.Show();
        }

        public AbstractPresenter(IKernel kernel, IServiceFactory serviceFactory, T view)
        {
            _kernel = kernel;
            _serviceFactory = serviceFactory;
            _view = view;
        }
    }
}
