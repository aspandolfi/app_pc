using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ControleBO.Domain.DataObjects
{
    public class DataTableObject
    {
        public DataTableObject()
        {
            Headers = new Collection<DataTableHeaderTitle>();
            DataSet = new Collection<IEnumerable<object>>();
        }

        public ICollection<DataTableHeaderTitle> Headers { get; }
        public ICollection<IEnumerable<object>> DataSet { get; }

        public void AddHeader(string title)
        {
            Headers.Add(new DataTableHeaderTitle(title));
        }

        public void AddHeaders(IEnumerable<string> titles)
        {
            foreach (var title in titles)
            {
                Headers.Add(new DataTableHeaderTitle(title));
            }
        }

        public void AddHeaders(params string[] titles)
        {
            for (int i = 0; i < titles.Length; i++)
            {
                Headers.Add(new DataTableHeaderTitle(titles[i]));
            }
        }

        public void AddDataSet(IEnumerable<object> collection)
        {
            DataSet.Add(collection);
        }

        public void AddDataSet(IEnumerable<IEnumerable<object>> dataSet)
        {
            foreach (var data in dataSet)
            {
                AddDataSet(data);
            }
        }
    }

    public class DataTableHeaderTitle
    {
        public DataTableHeaderTitle(string title)
        {
            Title = title;
        }
        public string Title { get; }
    }
}
