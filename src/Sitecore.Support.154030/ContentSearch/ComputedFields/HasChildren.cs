using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.SecurityModel;

namespace Sitecore.Support.ContentSearch.ComputedFields
{
    public class HasChildren : IComputedIndexField
    {
        public string FieldName
        {
            get;
            set;
        }

        public string ReturnType
        {
            get;
            set;
        }

        public object ComputeFieldValue(IIndexable indexable)
        {
            Item item = indexable as SitecoreIndexableItem;
            if (item == null)
            {
                return null;
            }
            SecurityCheck securityCheck = SecurityStateSwitcher.CurrentValue == SecurityState.Disabled ? SecurityCheck.Disable : SecurityCheck.Enable;
            return ItemManager.HasChildren(item, securityCheck);
        }
    }
}