// <fileinfo name="CTACTE_PLANES_DESEMB_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/> that 
	/// represents a record in the <c>CTACTE_PLANES_DESEMB_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_PLANES_DESEMB_INFO_COMPRow_Base
	{
		private string _proc_tarjeta_nombre;
		private string _cond_desembolso_descripcion;
		private string _cond_desembolso_nombre;
		private string _red_pago_nombre;
		private string _nombre;
		private decimal _id;
		private decimal _ctacte_procesadora_id;
		private bool _ctacte_procesadora_idNull = true;
		private decimal _ctacte_red_pago_id;
		private bool _ctacte_red_pago_idNull = true;
		private string _usar_validez;
		private System.DateTime _validez_desde;
		private bool _validez_desdeNull = true;
		private System.DateTime _validez_hasta;
		private bool _validez_hastaNull = true;
		private decimal _condicion_desembolso_id;
		private decimal _politica_primer_desembolso;
		private decimal _dias_desde_inicio_mes;
		private string _desembolso_automatico;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_PLANES_DESEMB_INFO_COMPRow_Base"/> class.
		/// </summary>
		public CTACTE_PLANES_DESEMB_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_PLANES_DESEMB_INFO_COMPRow_Base original)
		{
			if (this.PROC_TARJETA_NOMBRE != original.PROC_TARJETA_NOMBRE) return true;
			if (this.COND_DESEMBOLSO_DESCRIPCION != original.COND_DESEMBOLSO_DESCRIPCION) return true;
			if (this.COND_DESEMBOLSO_NOMBRE != original.COND_DESEMBOLSO_NOMBRE) return true;
			if (this.RED_PAGO_NOMBRE != original.RED_PAGO_NOMBRE) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.ID != original.ID) return true;
			if (this.IsCTACTE_PROCESADORA_IDNull != original.IsCTACTE_PROCESADORA_IDNull) return true;
			if (!this.IsCTACTE_PROCESADORA_IDNull && !original.IsCTACTE_PROCESADORA_IDNull)
				if (this.CTACTE_PROCESADORA_ID != original.CTACTE_PROCESADORA_ID) return true;
			if (this.IsCTACTE_RED_PAGO_IDNull != original.IsCTACTE_RED_PAGO_IDNull) return true;
			if (!this.IsCTACTE_RED_PAGO_IDNull && !original.IsCTACTE_RED_PAGO_IDNull)
				if (this.CTACTE_RED_PAGO_ID != original.CTACTE_RED_PAGO_ID) return true;
			if (this.USAR_VALIDEZ != original.USAR_VALIDEZ) return true;
			if (this.IsVALIDEZ_DESDENull != original.IsVALIDEZ_DESDENull) return true;
			if (!this.IsVALIDEZ_DESDENull && !original.IsVALIDEZ_DESDENull)
				if (this.VALIDEZ_DESDE != original.VALIDEZ_DESDE) return true;
			if (this.IsVALIDEZ_HASTANull != original.IsVALIDEZ_HASTANull) return true;
			if (!this.IsVALIDEZ_HASTANull && !original.IsVALIDEZ_HASTANull)
				if (this.VALIDEZ_HASTA != original.VALIDEZ_HASTA) return true;
			if (this.CONDICION_DESEMBOLSO_ID != original.CONDICION_DESEMBOLSO_ID) return true;
			if (this.POLITICA_PRIMER_DESEMBOLSO != original.POLITICA_PRIMER_DESEMBOLSO) return true;
			if (this.DIAS_DESDE_INICIO_MES != original.DIAS_DESDE_INICIO_MES) return true;
			if (this.DESEMBOLSO_AUTOMATICO != original.DESEMBOLSO_AUTOMATICO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>PROC_TARJETA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROC_TARJETA_NOMBRE</c> column value.</value>
		public string PROC_TARJETA_NOMBRE
		{
			get { return _proc_tarjeta_nombre; }
			set { _proc_tarjeta_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COND_DESEMBOLSO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COND_DESEMBOLSO_DESCRIPCION</c> column value.</value>
		public string COND_DESEMBOLSO_DESCRIPCION
		{
			get { return _cond_desembolso_descripcion; }
			set { _cond_desembolso_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COND_DESEMBOLSO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COND_DESEMBOLSO_NOMBRE</c> column value.</value>
		public string COND_DESEMBOLSO_NOMBRE
		{
			get { return _cond_desembolso_nombre; }
			set { _cond_desembolso_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RED_PAGO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RED_PAGO_NOMBRE</c> column value.</value>
		public string RED_PAGO_NOMBRE
		{
			get { return _red_pago_nombre; }
			set { _red_pago_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
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
		/// Gets or sets the <c>CTACTE_PROCESADORA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_PROCESADORA_ID</c> column value.</value>
		public decimal CTACTE_PROCESADORA_ID
		{
			get
			{
				if(IsCTACTE_PROCESADORA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_procesadora_id;
			}
			set
			{
				_ctacte_procesadora_idNull = false;
				_ctacte_procesadora_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_PROCESADORA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_PROCESADORA_IDNull
		{
			get { return _ctacte_procesadora_idNull; }
			set { _ctacte_procesadora_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_RED_PAGO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_RED_PAGO_ID</c> column value.</value>
		public decimal CTACTE_RED_PAGO_ID
		{
			get
			{
				if(IsCTACTE_RED_PAGO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_red_pago_id;
			}
			set
			{
				_ctacte_red_pago_idNull = false;
				_ctacte_red_pago_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_RED_PAGO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_RED_PAGO_IDNull
		{
			get { return _ctacte_red_pago_idNull; }
			set { _ctacte_red_pago_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USAR_VALIDEZ</c> column value.
		/// </summary>
		/// <value>The <c>USAR_VALIDEZ</c> column value.</value>
		public string USAR_VALIDEZ
		{
			get { return _usar_validez; }
			set { _usar_validez = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALIDEZ_DESDE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALIDEZ_DESDE</c> column value.</value>
		public System.DateTime VALIDEZ_DESDE
		{
			get
			{
				if(IsVALIDEZ_DESDENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _validez_desde;
			}
			set
			{
				_validez_desdeNull = false;
				_validez_desde = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALIDEZ_DESDE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALIDEZ_DESDENull
		{
			get { return _validez_desdeNull; }
			set { _validez_desdeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALIDEZ_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALIDEZ_HASTA</c> column value.</value>
		public System.DateTime VALIDEZ_HASTA
		{
			get
			{
				if(IsVALIDEZ_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _validez_hasta;
			}
			set
			{
				_validez_hastaNull = false;
				_validez_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALIDEZ_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALIDEZ_HASTANull
		{
			get { return _validez_hastaNull; }
			set { _validez_hastaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_DESEMBOLSO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONDICION_DESEMBOLSO_ID</c> column value.</value>
		public decimal CONDICION_DESEMBOLSO_ID
		{
			get { return _condicion_desembolso_id; }
			set { _condicion_desembolso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>POLITICA_PRIMER_DESEMBOLSO</c> column value.
		/// </summary>
		/// <value>The <c>POLITICA_PRIMER_DESEMBOLSO</c> column value.</value>
		public decimal POLITICA_PRIMER_DESEMBOLSO
		{
			get { return _politica_primer_desembolso; }
			set { _politica_primer_desembolso = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_DESDE_INICIO_MES</c> column value.
		/// </summary>
		/// <value>The <c>DIAS_DESDE_INICIO_MES</c> column value.</value>
		public decimal DIAS_DESDE_INICIO_MES
		{
			get { return _dias_desde_inicio_mes; }
			set { _dias_desde_inicio_mes = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESEMBOLSO_AUTOMATICO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESEMBOLSO_AUTOMATICO</c> column value.</value>
		public string DESEMBOLSO_AUTOMATICO
		{
			get { return _desembolso_automatico; }
			set { _desembolso_automatico = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@PROC_TARJETA_NOMBRE=");
			dynStr.Append(PROC_TARJETA_NOMBRE);
			dynStr.Append("@CBA@COND_DESEMBOLSO_DESCRIPCION=");
			dynStr.Append(COND_DESEMBOLSO_DESCRIPCION);
			dynStr.Append("@CBA@COND_DESEMBOLSO_NOMBRE=");
			dynStr.Append(COND_DESEMBOLSO_NOMBRE);
			dynStr.Append("@CBA@RED_PAGO_NOMBRE=");
			dynStr.Append(RED_PAGO_NOMBRE);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@CTACTE_PROCESADORA_ID=");
			dynStr.Append(IsCTACTE_PROCESADORA_IDNull ? (object)"<NULL>" : CTACTE_PROCESADORA_ID);
			dynStr.Append("@CBA@CTACTE_RED_PAGO_ID=");
			dynStr.Append(IsCTACTE_RED_PAGO_IDNull ? (object)"<NULL>" : CTACTE_RED_PAGO_ID);
			dynStr.Append("@CBA@USAR_VALIDEZ=");
			dynStr.Append(USAR_VALIDEZ);
			dynStr.Append("@CBA@VALIDEZ_DESDE=");
			dynStr.Append(IsVALIDEZ_DESDENull ? (object)"<NULL>" : VALIDEZ_DESDE);
			dynStr.Append("@CBA@VALIDEZ_HASTA=");
			dynStr.Append(IsVALIDEZ_HASTANull ? (object)"<NULL>" : VALIDEZ_HASTA);
			dynStr.Append("@CBA@CONDICION_DESEMBOLSO_ID=");
			dynStr.Append(CONDICION_DESEMBOLSO_ID);
			dynStr.Append("@CBA@POLITICA_PRIMER_DESEMBOLSO=");
			dynStr.Append(POLITICA_PRIMER_DESEMBOLSO);
			dynStr.Append("@CBA@DIAS_DESDE_INICIO_MES=");
			dynStr.Append(DIAS_DESDE_INICIO_MES);
			dynStr.Append("@CBA@DESEMBOLSO_AUTOMATICO=");
			dynStr.Append(DESEMBOLSO_AUTOMATICO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_PLANES_DESEMB_INFO_COMPRow_Base class
} // End of namespace
