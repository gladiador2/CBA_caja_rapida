// <fileinfo name="FICHAS_MEDICA_REMEDIOSRow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="FICHAS_MEDICA_REMEDIOSRow"/> that 
	/// represents a record in the <c>FICHAS_MEDICA_REMEDIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FICHAS_MEDICA_REMEDIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FICHAS_MEDICA_REMEDIOSRow_Base
	{
		private decimal _id;
		private decimal _fichas_medica_id;
		private bool _fichas_medica_idNull = true;
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _lote_id;
		private bool _lote_idNull = true;
		private decimal _dosis;
		private bool _dosisNull = true;
		private decimal _dosis_total;
		private bool _dosis_totalNull = true;
		private decimal _cantidad_unidad_medida;
		private bool _cantidad_unidad_medidaNull = true;
		private string _ruae;
		private string _intervalo_dosis;
		private string _observacion;
		private string _afecta_stock;

		/// <summary>
		/// Initializes a new instance of the <see cref="FICHAS_MEDICA_REMEDIOSRow_Base"/> class.
		/// </summary>
		public FICHAS_MEDICA_REMEDIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FICHAS_MEDICA_REMEDIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFICHAS_MEDICA_IDNull != original.IsFICHAS_MEDICA_IDNull) return true;
			if (!this.IsFICHAS_MEDICA_IDNull && !original.IsFICHAS_MEDICA_IDNull)
				if (this.FICHAS_MEDICA_ID != original.FICHAS_MEDICA_ID) return true;
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsLOTE_IDNull != original.IsLOTE_IDNull) return true;
			if (!this.IsLOTE_IDNull && !original.IsLOTE_IDNull)
				if (this.LOTE_ID != original.LOTE_ID) return true;
			if (this.IsDOSISNull != original.IsDOSISNull) return true;
			if (!this.IsDOSISNull && !original.IsDOSISNull)
				if (this.DOSIS != original.DOSIS) return true;
			if (this.IsDOSIS_TOTALNull != original.IsDOSIS_TOTALNull) return true;
			if (!this.IsDOSIS_TOTALNull && !original.IsDOSIS_TOTALNull)
				if (this.DOSIS_TOTAL != original.DOSIS_TOTAL) return true;
			if (this.IsCANTIDAD_UNIDAD_MEDIDANull != original.IsCANTIDAD_UNIDAD_MEDIDANull) return true;
			if (!this.IsCANTIDAD_UNIDAD_MEDIDANull && !original.IsCANTIDAD_UNIDAD_MEDIDANull)
				if (this.CANTIDAD_UNIDAD_MEDIDA != original.CANTIDAD_UNIDAD_MEDIDA) return true;
			if (this.RUAE != original.RUAE) return true;
			if (this.INTERVALO_DOSIS != original.INTERVALO_DOSIS) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.AFECTA_STOCK != original.AFECTA_STOCK) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FICHAS_MEDICA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FICHAS_MEDICA_ID</c> column value.</value>
		public decimal FICHAS_MEDICA_ID
		{
			get
			{
				if(IsFICHAS_MEDICA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fichas_medica_id;
			}
			set
			{
				_fichas_medica_idNull = false;
				_fichas_medica_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FICHAS_MEDICA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFICHAS_MEDICA_IDNull
		{
			get { return _fichas_medica_idNull; }
			set { _fichas_medica_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LOTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOTE_ID</c> column value.</value>
		public decimal LOTE_ID
		{
			get
			{
				if(IsLOTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lote_id;
			}
			set
			{
				_lote_idNull = false;
				_lote_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOTE_IDNull
		{
			get { return _lote_idNull; }
			set { _lote_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DOSIS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DOSIS</c> column value.</value>
		public decimal DOSIS
		{
			get
			{
				if(IsDOSISNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dosis;
			}
			set
			{
				_dosisNull = false;
				_dosis = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DOSIS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDOSISNull
		{
			get { return _dosisNull; }
			set { _dosisNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DOSIS_TOTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DOSIS_TOTAL</c> column value.</value>
		public decimal DOSIS_TOTAL
		{
			get
			{
				if(IsDOSIS_TOTALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dosis_total;
			}
			set
			{
				_dosis_totalNull = false;
				_dosis_total = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DOSIS_TOTAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDOSIS_TOTALNull
		{
			get { return _dosis_totalNull; }
			set { _dosis_totalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_UNIDAD_MEDIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_UNIDAD_MEDIDA</c> column value.</value>
		public decimal CANTIDAD_UNIDAD_MEDIDA
		{
			get
			{
				if(IsCANTIDAD_UNIDAD_MEDIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_unidad_medida;
			}
			set
			{
				_cantidad_unidad_medidaNull = false;
				_cantidad_unidad_medida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_UNIDAD_MEDIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_UNIDAD_MEDIDANull
		{
			get { return _cantidad_unidad_medidaNull; }
			set { _cantidad_unidad_medidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUAE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUAE</c> column value.</value>
		public string RUAE
		{
			get { return _ruae; }
			set { _ruae = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INTERVALO_DOSIS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INTERVALO_DOSIS</c> column value.</value>
		public string INTERVALO_DOSIS
		{
			get { return _intervalo_dosis; }
			set { _intervalo_dosis = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AFECTA_STOCK</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AFECTA_STOCK</c> column value.</value>
		public string AFECTA_STOCK
		{
			get { return _afecta_stock; }
			set { _afecta_stock = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FICHAS_MEDICA_ID=");
			dynStr.Append(IsFICHAS_MEDICA_IDNull ? (object)"<NULL>" : FICHAS_MEDICA_ID);
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@LOTE_ID=");
			dynStr.Append(IsLOTE_IDNull ? (object)"<NULL>" : LOTE_ID);
			dynStr.Append("@CBA@DOSIS=");
			dynStr.Append(IsDOSISNull ? (object)"<NULL>" : DOSIS);
			dynStr.Append("@CBA@DOSIS_TOTAL=");
			dynStr.Append(IsDOSIS_TOTALNull ? (object)"<NULL>" : DOSIS_TOTAL);
			dynStr.Append("@CBA@CANTIDAD_UNIDAD_MEDIDA=");
			dynStr.Append(IsCANTIDAD_UNIDAD_MEDIDANull ? (object)"<NULL>" : CANTIDAD_UNIDAD_MEDIDA);
			dynStr.Append("@CBA@RUAE=");
			dynStr.Append(RUAE);
			dynStr.Append("@CBA@INTERVALO_DOSIS=");
			dynStr.Append(INTERVALO_DOSIS);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@AFECTA_STOCK=");
			dynStr.Append(AFECTA_STOCK);
			return dynStr.ToString();
		}
	} // End of FICHAS_MEDICA_REMEDIOSRow_Base class
} // End of namespace
