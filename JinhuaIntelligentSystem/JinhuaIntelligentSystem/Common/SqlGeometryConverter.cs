using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace JinhuaIntelligentSystem.Common
{
    public class SqlGeometryConverter : OrmLiteConverter
    {
        public override string ColumnDefinition
        {
            get { return "geometry"; }
        }

        public override DbType DbType
        {
            get { return DbType.Object; }
        }

        //public override void InitDbParam(IDbDataParameter p, Type fieldType)
        //{
        //    ((NpgsqlParameter)p).NpgsqlDbType = NpgsqlDbType.Geometry;
        //}
    }
}