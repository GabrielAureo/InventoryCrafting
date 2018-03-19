using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

public class Container{
    public List<IContainable> items;

    public delegate void ItemAdditionHandler(IContainable item, int count);
    public delegate int ItemRemovalHandler(string itemName, int count);

    public event ItemAdditionHandler ItemAddition;
    public event ItemRemovalHandler ItemRemoval;
    public Container(List<IContainable> items){
        this.items = items;
    }

    public void addItem(IContainable item, int count){
        for (int i =0; i < count; i++){
            items.Add(item);
        }
        ItemAddition(item, count);
    }

    public int removeItem(string itemName, int count){
        /*var result = items.Where(x => x.name.Equals(itemName, StringComparison.CurrentCultureIgnoreCase));
        var removeCount = Math.Min(result.Count(), count);
        items = items.Except(result).ToList();*/

        int removeCount = 0;

        foreach(var item in items){
            if(item.getID().Equals(itemName, StringComparison.CurrentCultureIgnoreCase)){
                items.Remove(item);
                removeCount++;
            }
        }
        ItemRemoval(itemName, removeCount);

  
        return removeCount;
        
    }

    public FilteredList<E> filterByType<E>() where E: IContainable{
        return new FilteredList<E>(items.OfType<E>().ToList());
    }


}

public class FilteredList<T>{
    private List<T> list;
    public bool isDirty;

    public FilteredList(List<T> list, bool isDirty = false){
        this.list = list;
        this.isDirty = isDirty;
    }


    
}