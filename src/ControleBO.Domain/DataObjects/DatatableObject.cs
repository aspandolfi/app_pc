using System.Collections.Generic;

namespace ControleBO.Domain.DataObjects
{
    public class DatatableObject
    {
        public DatatableObject()
        {
            Headers = new List<DatatableHeaderTitle>();
            DataSet = new List<List<object>>();
        }

        public IList<DatatableHeaderTitle> Headers { get; }
        public IList<List<object>> DataSet { get; }

        public void AddHeader(string title)
        {
            Headers.Add(new DatatableHeaderTitle(title));
        }

        public void AddHeaders(IEnumerable<string> titles)
        {
            foreach (var title in titles)
            {
                Headers.Add(new DatatableHeaderTitle(title));
            }
        }

        public void AddDataSet(List<object> dataSet)
        {
            DataSet.Add(dataSet);
        }

        public void AddDataSet(List<List<object>> dataSet)
        {
            foreach (var data in dataSet)
            {
                DataSet.Add(data);
            }
        }
    }

    public class DatatableHeaderTitle
    {
        public DatatableHeaderTitle(string title)
        {
            Title = title;
        }
        public string Title { get; }
    }
}
