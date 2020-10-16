using System.Windows.Input;

namespace MaterMinds.Interfaces
{
    interface IHaveSound
    {
        public ICommand MuteCommand { get; set; }
    }
}
