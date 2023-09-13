
using Cysharp.Threading.Tasks;

public interface IWindowService
{
    public UniTask Hide();

    public UniTask Show();

    public UniTask Initialize(object data);
}
