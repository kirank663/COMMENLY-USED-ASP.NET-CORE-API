using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CommenReactProjectAPI.CommenFunction
{
      public class CommenFunctions
      {
            public static List<T> ConvertDataTableToList<T>(DataTable dt) where T : new()
            {
                  List<T> list = new List<T>();
                  if(dt != null && dt.Rows.Count > 0)
                  {
                        foreach(DataRow row in dt.Rows)
                        {
                              T obj = new T();
                              foreach(DataColumn col in dt.Columns)
                              {
                                    var prop = obj.GetType().GetProperty(col.ColumnName);

                                    if(prop != null && row[col] != DBNull.Value)
                                          prop.SetValue(obj , row[col]);
                              }
                              list.Add(obj);
                        }
                  }
                  return list;
            }
      }
}
