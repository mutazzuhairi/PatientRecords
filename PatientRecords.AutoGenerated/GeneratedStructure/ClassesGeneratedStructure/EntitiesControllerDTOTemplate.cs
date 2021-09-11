﻿using PatientRecords.AutoGenerated.HelperClasses;
using PatientRecords.AutoGenerated.HelperClasses.Interfaces;

namespace PatientRecords.AutoGenerated.GeneratedStructure.ClassesGeneratedStructure
{
    public partial class EntitiesControllerViewTemplate : ITextTemplate
    {

        /// <summary>
        /// Entity's Namespace.
        /// </summary>
        public string NameSpace { get; }

        /// <summary>
        /// Table Data.
        /// </summary>
        public TableInfo Table { get; }

        /// <summary>
        /// Creates an Instance of TableEntityTemplate.
        /// </summary>
        /// <param name="nameSpace">Entity's Namespace.</param>
        /// <param name="table">Table Data.</param>
        public EntitiesControllerViewTemplate(string nameSpace, TableInfo table)
            => (NameSpace, Table) = (nameSpace, table);


    }
}
