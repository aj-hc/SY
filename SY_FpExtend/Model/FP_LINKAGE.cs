using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuRo.Model
{
    public class FP_LINKAGE
    {
        public FP_LINKAGE()
        { }
        #region Model
        private int _id;
        private int _fromid;
        private string _name;
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public int fromid
        {
            set { _fromid = value; }
            get { return _fromid; }
        }
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        #endregion endModel
    }
}
