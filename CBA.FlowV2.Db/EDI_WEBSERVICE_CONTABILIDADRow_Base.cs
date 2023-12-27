// <fileinfo name="EDI_WEBSERVICE_CONTABILIDADRow_Base.cs">
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
	/// The base class for <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/> that 
	/// represents a record in the <c>EDI_WEBSERVICE_CONTABILIDAD</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EDI_WEBSERVICE_CONTABILIDADRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EDI_WEBSERVICE_CONTABILIDADRow_Base
	{
		private decimal _id;
		private bool _idNull = true;
		private string _edi;
		private decimal _asiento_automatico_id;
		private bool _asiento_automatico_idNull = true;
		private decimal _asiento_id;
		private bool _asiento_idNull = true;
		private string _regenerar;
		private string _eliminado;
		private decimal _mkt_flujo_id;
		private bool _mkt_flujo_idNull = true;
		private decimal _mkt_caso_id;
		private bool _mkt_caso_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="EDI_WEBSERVICE_CONTABILIDADRow_Base"/> class.
		/// </summary>
		public EDI_WEBSERVICE_CONTABILIDADRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EDI_WEBSERVICE_CONTABILIDADRow_Base original)
		{
			if (this.IsIDNull != original.IsIDNull) return true;
			if (!this.IsIDNull && !original.IsIDNull)
				if (this.ID != original.ID) return true;
			if (this.EDI != original.EDI) return true;
			if (this.IsASIENTO_AUTOMATICO_IDNull != original.IsASIENTO_AUTOMATICO_IDNull) return true;
			if (!this.IsASIENTO_AUTOMATICO_IDNull && !original.IsASIENTO_AUTOMATICO_IDNull)
				if (this.ASIENTO_AUTOMATICO_ID != original.ASIENTO_AUTOMATICO_ID) return true;
			if (this.IsASIENTO_IDNull != original.IsASIENTO_IDNull) return true;
			if (!this.IsASIENTO_IDNull && !original.IsASIENTO_IDNull)
				if (this.ASIENTO_ID != original.ASIENTO_ID) return true;
			if (this.REGENERAR != original.REGENERAR) return true;
			if (this.ELIMINADO != original.ELIMINADO) return true;
			if (this.IsMKT_FLUJO_IDNull != original.IsMKT_FLUJO_IDNull) return true;
			if (!this.IsMKT_FLUJO_IDNull && !original.IsMKT_FLUJO_IDNull)
				if (this.MKT_FLUJO_ID != original.MKT_FLUJO_ID) return true;
			if (this.IsMKT_CASO_IDNull != original.IsMKT_CASO_IDNull) return true;
			if (!this.IsMKT_CASO_IDNull && !original.IsMKT_CASO_IDNull)
				if (this.MKT_CASO_ID != original.MKT_CASO_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get
			{
				if(IsIDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _id;
			}
			set
			{
				_idNull = false;
				_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsIDNull
		{
			get { return _idNull; }
			set { _idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EDI</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EDI</c> column value.</value>
		public string EDI
		{
			get { return _edi; }
			set { _edi = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ASIENTO_AUTOMATICO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ASIENTO_AUTOMATICO_ID</c> column value.</value>
		public decimal ASIENTO_AUTOMATICO_ID
		{
			get
			{
				if(IsASIENTO_AUTOMATICO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _asiento_automatico_id;
			}
			set
			{
				_asiento_automatico_idNull = false;
				_asiento_automatico_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ASIENTO_AUTOMATICO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsASIENTO_AUTOMATICO_IDNull
		{
			get { return _asiento_automatico_idNull; }
			set { _asiento_automatico_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ASIENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ASIENTO_ID</c> column value.</value>
		public decimal ASIENTO_ID
		{
			get
			{
				if(IsASIENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _asiento_id;
			}
			set
			{
				_asiento_idNull = false;
				_asiento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ASIENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsASIENTO_IDNull
		{
			get { return _asiento_idNull; }
			set { _asiento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGENERAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGENERAR</c> column value.</value>
		public string REGENERAR
		{
			get { return _regenerar; }
			set { _regenerar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ELIMINADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ELIMINADO</c> column value.</value>
		public string ELIMINADO
		{
			get { return _eliminado; }
			set { _eliminado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MKT_FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MKT_FLUJO_ID</c> column value.</value>
		public decimal MKT_FLUJO_ID
		{
			get
			{
				if(IsMKT_FLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _mkt_flujo_id;
			}
			set
			{
				_mkt_flujo_idNull = false;
				_mkt_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MKT_FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMKT_FLUJO_IDNull
		{
			get { return _mkt_flujo_idNull; }
			set { _mkt_flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MKT_CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MKT_CASO_ID</c> column value.</value>
		public decimal MKT_CASO_ID
		{
			get
			{
				if(IsMKT_CASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _mkt_caso_id;
			}
			set
			{
				_mkt_caso_idNull = false;
				_mkt_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MKT_CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMKT_CASO_IDNull
		{
			get { return _mkt_caso_idNull; }
			set { _mkt_caso_idNull = value; }
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
			dynStr.Append(IsIDNull ? (object)"<NULL>" : ID);
			dynStr.Append("@CBA@EDI=");
			dynStr.Append(EDI);
			dynStr.Append("@CBA@ASIENTO_AUTOMATICO_ID=");
			dynStr.Append(IsASIENTO_AUTOMATICO_IDNull ? (object)"<NULL>" : ASIENTO_AUTOMATICO_ID);
			dynStr.Append("@CBA@ASIENTO_ID=");
			dynStr.Append(IsASIENTO_IDNull ? (object)"<NULL>" : ASIENTO_ID);
			dynStr.Append("@CBA@REGENERAR=");
			dynStr.Append(REGENERAR);
			dynStr.Append("@CBA@ELIMINADO=");
			dynStr.Append(ELIMINADO);
			dynStr.Append("@CBA@MKT_FLUJO_ID=");
			dynStr.Append(IsMKT_FLUJO_IDNull ? (object)"<NULL>" : MKT_FLUJO_ID);
			dynStr.Append("@CBA@MKT_CASO_ID=");
			dynStr.Append(IsMKT_CASO_IDNull ? (object)"<NULL>" : MKT_CASO_ID);
			return dynStr.ToString();
		}
	} // End of EDI_WEBSERVICE_CONTABILIDADRow_Base class
} // End of namespace
