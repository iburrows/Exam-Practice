using Example_8_Client.ClientCom;
using GalaSoft.MvvmLight;

namespace Example_8_Client.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        Client client;

        public MainViewModel()
        {
            client = new Client(10100);
        }
    }
}