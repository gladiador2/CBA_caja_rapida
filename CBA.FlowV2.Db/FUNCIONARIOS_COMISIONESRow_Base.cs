// <fileinfo name="FUNCIONARIOS_COMISIONESRow_Base.cs">
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
	/// The base class for <see cref="FUNCIONARIOS_COMISIONESRow"/> that 
	/// represents a record in the <c>FUNCIONARIOS_COMISIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="FUNCIONARIOS_COMISIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class FUNCIONARIOS_COMISIONESRow_Base
	{
		private decimal _id;
		private string _tipo_comision;
		private decimal _funcionario_id;
		private decimal _caso_id;
		private bool _caso_idNull = true;
		private System.DateTime _fecha;
		private decimal _moneda_id;
		private decimal _cotizacion;
		private decimal _monto;
		private string _cobrado;
		private decimal _funcionario_bonificacion_id;
		private bool _funcionario_bonificacion_idNull = true;
		private decimal _funcionario_descuento_id;
		private bool _funcionario_descuento_idNull = true;
		private decimal _anho;
		private bool _anhoNull = true;
		private decimal _temporada_id;
		private bool _temporada_idNull = true;
		private decimal _persona_id;
		private bool _persona_idNull = true;
		private string _tipo_funcionario;
		private decimal _ctacte_pago_persona_doc_id;
		private bool _ctacte_pago_persona_doc_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="FUNCIONARIOS_COMISIONESRow_Base"/> class.
		/// </summary>
		public FUNCIONARIOS_COMISIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(FUNCIONARIOS_COMISIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_COMISION != original.TIPO_COMISION) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsCASO_IDNull != original.IsCASO_IDNull) return true;
			if (!this.IsCASO_IDNull && !original.IsCASO_IDNull)
				if (this.CASO_ID != original.CASO_ID) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.COTIZACION != original.COTIZACION) return true;
			if (this.MONTO != original.MONTO) return true;
			if (this.COBRADO != original.COBRADO) return true;
			if (this.IsFUNCIONARIO_BONIFICACION_IDNull != original.IsFUNCIONARIO_BONIFICACION_IDNull) return true;
			if (!this.IsFUNCIONARIO_BONIFICACION_IDNull && !original.IsFUNCIONARIO_BONIFICACION_IDNull)
				if (this.FUNCIONARIO_BONIFICACION_ID != original.FUNCIONARIO_BONIFICACION_ID) return true;
			if (this.IsFUNCIONARIO_DESCUENTO_IDNull != original.IsFUNCIONARIO_DESCUENTO_IDNull) return true;
			if (!this.IsFUNCIONARIO_DESCUENTO_IDNull && !original.IsFUNCIONARIO_DESCUENTO_IDNull)
				if (this.FUNCIONARIO_DESCUENTO_ID != original.FUNCIONARIO_DESCUENTO_ID) return true;
			if (this.IsANHONull != original.IsANHONull) return true;
			if (!this.IsANHONull && !original.IsANHONull)
				if (this.ANHO != original.ANHO) return true;
			if (this.IsTEMPORADA_IDNull != original.IsTEMPORADA_IDNull) return true;
			if (!this.IsTEMPORADA_IDNull && !original.IsTEMPORADA_IDNull)
				if (this.TEMPORADA_ID != original.TEMPORADA_ID) return true;
			if (this.IsPERSONA_IDNull != original.IsPERSONA_IDNull) return true;
			if (!this.IsPERSONA_IDNull && !original.IsPERSONA_IDNull)
				if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.TIPO_FUNCIONARIO != original.TIPO_FUNCIONARIO) return true;
			if (this.IsCTACTE_PAGO_PERSONA_DOC_IDNull != original.IsCTACTE_PAGO_PERSONA_DOC_IDNull) return true;
			if (!this.IsCTACTE_PAGO_PERSONA_DOC_IDNull && !original.IsCTACTE_PAGO_PERSONA_DOC_IDNull)
				if (this.CTACTE_PAGO_PERSONA_DOC_ID != original.CTACTE_PAGO_PERSONA_DOC_ID) return true;
			
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
		/// Gets or sets the <c>TIPO_COMISION</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_COMISION</c> column value.</value>
		public string TIPO_COMISION
		{
			get { return _tipo_comision; }
			set { _tipo_comision = value; }
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get
			{
				if(IsCASO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _caso_id;
			}
			set
			{
				_caso_idNull = false;
				_caso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CASO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCASO_IDNull
		{
			get { return _caso_idNull; }
			set { _caso_idNull = value; }
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
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get { return _moneda_id; }
			set { _moneda_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COTIZACION</c> column value.
		/// </summary>
		/// <value>The <c>COTIZACION</c> column value.</value>
		public decimal COTIZACION
		{
			get { return _cotizacion; }
			set { _cotizacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get { return _monto; }
			set { _monto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COBRADO</c> column value.
		/// </summary>
		/// <value>The <c>COBRADO</c> column value.</value>
		public string COBRADO
		{
			get { return _cobrado; }
			set { _cobrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_BONIFICACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_BONIFICACION_ID</c> column value.</value>
		public decimal FUNCIONARIO_BONIFICACION_ID
		{
			get
			{
				if(IsFUNCIONARIO_BONIFICACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_bonificacion_id;
			}
			set
			{
				_funcionario_bonificacion_idNull = false;
				_funcionario_bonificacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_BONIFICACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_BONIFICACION_IDNull
		{
			get { return _funcionario_bonificacion_idNull; }
			set { _funcionario_bonificacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_DESCUENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_DESCUENTO_ID</c> column value.</value>
		public decimal FUNCIONARIO_DESCUENTO_ID
		{
			get
			{
				if(IsFUNCIONARIO_DESCUENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_descuento_id;
			}
			set
			{
				_funcionario_descuento_idNull = false;
				_funcionario_descuento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_DESCUENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_DESCUENTO_IDNull
		{
			get { return _funcionario_descuento_idNull; }
			set { _funcionario_descuento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANHO</c> column value.</value>
		public decimal ANHO
		{
			get
			{
				if(IsANHONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anho;
			}
			set
			{
				_anhoNull = false;
				_anho = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANHO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANHONull
		{
			get { return _anhoNull; }
			set { _anhoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEMPORADA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEMPORADA_ID</c> column value.</value>
		public decimal TEMPORADA_ID
		{
			get
			{
				if(IsTEMPORADA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _temporada_id;
			}
			set
			{
				_temporada_idNull = false;
				_temporada_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEMPORADA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEMPORADA_IDNull
		{
			get { return _temporada_idNull; }
			set { _temporada_idNull = value; }
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
		/// Gets or sets the <c>TIPO_FUNCIONARIO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_FUNCIONARIO</c> column value.</value>
		public string TIPO_FUNCIONARIO
		{
			get { return _tipo_funcionario; }
			set { _tipo_funcionario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PAGO_PERSONA_DOC_ID</c> column value.</value>
		public decimal CTACTE_PAGO_PERSONA_DOC_ID
		{
			get
			{
				if(IsCTACTE_PAGO_PERSONA_DOC_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_pago_persona_doc_id;
			}
			set
			{
				_ctacte_pago_persona_doc_idNull = false;
				_ctacte_pago_persona_doc_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PAGO_PERSONA_DOC_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PAGO_PERSONA_DOC_IDNull
		{
			get { return _ctacte_pago_persona_doc_idNull; }
			set { _ctacte_pago_persona_doc_idNull = value; }
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
			dynStr.Append("@CBA@TIPO_COMISION=");
			dynStr.Append(TIPO_COMISION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(IsCASO_IDNull ? (object)"<NULL>" : CASO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(MONEDA_ID);
			dynStr.Append("@CBA@COTIZACION=");
			dynStr.Append(COTIZACION);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(MONTO);
			dynStr.Append("@CBA@COBRADO=");
			dynStr.Append(COBRADO);
			dynStr.Append("@CBA@FUNCIONARIO_BONIFICACION_ID=");
			dynStr.Append(IsFUNCIONARIO_BONIFICACION_IDNull ? (object)"<NULL>" : FUNCIONARIO_BONIFICACION_ID);
			dynStr.Append("@CBA@FUNCIONARIO_DESCUENTO_ID=");
			dynStr.Append(IsFUNCIONARIO_DESCUENTO_IDNull ? (object)"<NULL>" : FUNCIONARIO_DESCUENTO_ID);
			dynStr.Append("@CBA@ANHO=");
			dynStr.Append(IsANHONull ? (object)"<NULL>" : ANHO);
			dynStr.Append("@CBA@TEMPORADA_ID=");
			dynStr.Append(IsTEMPORADA_IDNull ? (object)"<NULL>" : TEMPORADA_ID);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(IsPERSONA_IDNull ? (object)"<NULL>" : PERSONA_ID);
			dynStr.Append("@CBA@TIPO_FUNCIONARIO=");
			dynStr.Append(TIPO_FUNCIONARIO);
			dynStr.Append("@CBA@CTACTE_PAGO_PERSONA_DOC_ID=");
			dynStr.Append(IsCTACTE_PAGO_PERSONA_DOC_IDNull ? (object)"<NULL>" : CTACTE_PAGO_PERSONA_DOC_ID);
			return dynStr.ToString();
		}
	} // End of FUNCIONARIOS_COMISIONESRow_Base class
} // End of namespace
