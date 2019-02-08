/* /*/using System.Collections.Generic;
using System.Linq;
public interface TabFilter<out T> where T: IContainable{

    string[] getLabels();
    IEnumerable<IContainable> filterList(List<IContainable> list);

}
public class ItemTab : TabFilter<Item>
{
    public IEnumerable<IContainable> filterList(List<IContainable> list)
    {
        return (IEnumerable<IContainable>) list.OfType<Item>();
    }

    public string[] getLabels()
    {
        return new string[]{"name", "weight", "value"};
    }
}
public class WeaponTab : TabFilter<Weapon>
{
    public IEnumerable<IContainable> filterList(List<IContainable> list)
    {
       return (IEnumerable<IContainable>) list.OfType<Weapon>();
    }

    public string[] getLabels()
    {
        return new string[]{"name", "damage", "type", "weight", "value"};
    }
}