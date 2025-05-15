using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using System.Windows.Controls;

namespace PrismDemo.Core.Regions
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(RegionBehaviorFactory behaviorFactory)
            : base (behaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        // Logic that takes incoming view and add it to Stack Panel
        {
            
            region.Views.CollectionChanged += (s, e) => // Access the view and hook to CollectionChanged event
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems)
                    {
                        if (item is System.Windows.UIElement element) // Checks if the item is a UIElement first before adding
                        {
                            regionTarget.Children.Add(element);
                        }
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (var item in e.OldItems)
                   
                    {
                        if (item is System.Windows.UIElement element) // Checks if the item is a UIElement first before removing (Pattern Matching)
                        {
                            regionTarget.Children.Remove(element); // If dont check then it will throw an exception because regionTarget.Children only accept UIElement objects
                        }
                    }
                }
            };
        }
        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
