// <fileinfo name="PLANILLA_ASOC_FUNCIONARIOSRow_Base.cs">
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
	/// The base class for <see cref="PLANILLA_ASOC_FUNCIONARIOSRow"/> that 
	/// represents a record in the <c>PLANILLA_ASOC_FUNCIONARIOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLA_ASOC_FUNCIONARIOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLA_ASOC_FUNCIONARIOSRow_Base
	{
		private decimal _id;
		private decimal _funcionario_id;
		private System.DateTime _fecha;
		private decimal _caso_asociado_id;
		private bool _caso_asociado_idNull = true;
		private string _generado;
		private string _observacion;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private decimal _monto;
		private bool _montoNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _cotizacion;
		private bool _cotizacionNull = true;
		private string _estado;
		private string _nro_comprobante;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLA_ASOC_FUNCIONARIOSRow_Base"/> class.
		/// </summary>
		public PLANILLA_ASOC_FUNCIONARIOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLA_ASOC_FUNCIONARIOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.IsCASO_ASOCIADO_IDNull != original.IsCASO_ASOCIADO_IDNull) return true;
			if (!this.IsCASO_ASOCIADO_IDNull && !original.IsCASO_ASOCIADO_IDNull)
				if (this.CASO_ASOCIADO_ID != original.CASO_ASOCIADO_ID) return true;
			if (this.GENERADO != original.GENERADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsCOTIZACIONNull != original.IsCOTIZACIONNull) return true;
			if (!this.IsCOTIZACIONNull && !original.IsCOTIZACIONNull)
				if (this.COTIZACION != original.COTIZACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NRO_COMPROBANTE != original.NRO_COMPROBANTE) return true;
			
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get { return _fecha; }
			set { _fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CASO_ASOCIADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ASOCIADO_ID</c> column value.</value>
		public decimal CASO_ASOCIADO_ID
		{
			get
			{
				if(IsCASO_ASOCIADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_asociado_id;
			}
			set
			{
				_caso_asociado_idNull = false;
				_caso_asociado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ASOCIADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_ASOCIADO_IDNull
		{
			get { return _caso_asociado_idNull; }
			set { _caso_asociado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERADO</c> column value.
		/// </summary>
		/// <value>The <c>GENERADO</c> column value.</value>
		public string GENERADO
		{
			get { return _generado; }
			set { _generado = value; }
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
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get
			{
				if(IsPERSONA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _persona_id;
			}
			set
			{
				_persona_idNull = false;
				_persona_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERSONA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERSONA_IDNull
		{
			get { return _persona_idNull; }
			set { _persona_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get
			{
				if(IsCOTIZACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cotizacion;
			}
			set
			{
				_cotizacionNull = false;
				_cotizacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COTIZACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOTIZACIONNull
		{
			get { return _cotizacionNull; }
			set { _cotizacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_COMPROBANTE</c> column value.</value>
		public string NRO_COMPROBANTE
		{
			get { return _nro_comprobante; }
			set { _nro_comprobante = value; }
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
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@CASO_ASOCIADO_ID=");
			dynStr.Append(IsCASO_ASOCIADO_IDNull ? (object)"<NULL>" : CASO_ASOCIADO_ID);
			dynStr.Append("@CBA@GENERADO=");
			dynStr.Append(GENERADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(IsCOTIZACIONNull ? (object)"<NULL>" : COTIZACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NRO_COMPROBANTE=");
			dynStr.Append(NRO_COMPROBANTE);
			return dynStr.ToString();
		}
	} // End of PLANILLA_ASOC_FUNCIONARIOSRow_Base class
} // End of namespace
