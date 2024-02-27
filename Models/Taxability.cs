using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using SnapObjects.Data;
using DWNet.Data;
using Newtonsoft.Json;
using System.Collections;

namespace TaxabilityWebAPI.Models 
{
    [DataWindow("ds_get_taxability", DwStyle.Grid)]
    #region DwSelectAttribute  
    [DwSelect("select	@(_COLUMNS_PLACEHOLDER_) \r\n "
                  +"from   	co_state_tax_rule_defs \r\n "
                  +"where   	:s_order_rule_def like order_rule_def \r\n "
                  +"and		:s_item_rule_def like item_rule_def \r\n "
                  +"and     	[state] = :s_state \r\n "
                  +"and     	LOWER(SUBSTRING(state_def_name,1,7)) <> 'Default'")]
    #endregion
    [DwParameter("s_state", typeof(string))]
    [DwParameter("s_order_rule_def", typeof(string))]
    [DwParameter("s_item_rule_def", typeof(string))]
    public class Taxability
    {
        [StringLength(1)]
        [SqlCompute("isnull(taxable_flag,'E') as taxable_flag")]
        public string Taxable_Flag { get; set; } = string.Empty;

    }

}



