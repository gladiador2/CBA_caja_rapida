// <fileinfo name="ITEMS_INGRESO_DEP_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/> that 
	/// represents a record in the <c>ITEMS_INGRESO_DEP_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ITEMS_INGRESO_DEP_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _items_ingreso_id;
		private bool _items_ingreso_idNull = true;
		private System.DateTime _fecha_ingreso;
		private bool _fecha_ingresoNull = true;
		private System.DateTime _fecha_emision;
		private bool _fecha_emisionNull = true;
		private string _generacion_confirmada;
		private string _ingreso_confirmado;
		private string _numero_comprobante;
		private string _precintos;
		private System.DateTime _inicio;
		private bool _inicioNull = true;
		private System.DateTime _fin;
		private bool _finNull = true;
		private string _despacho;
		private string _ida3;
		private string _ic;
		private string _otros;
		private string _transportadora_nombre;
		private string _mic_dta;
		private decimal _peso_manifestado;
		private bool _peso_manifestadoNull = true;
		private string _fcl_lcl;
		private System.DateTime _fecha_ingreso_puerto;
		private bool _fecha_ingreso_puertoNull = true;
		private string _chapa;
		private string _tipo_camion_nombre;
		private string _contenedor_numero;
		private decimal _semana;
		private bool _semanaNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ITEMS_INGRESO_DEP_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public ITEMS_INGRESO_DEP_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ITEMS_INGRESO_DEP_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsITEMS_INGRESO_IDNull != original.IsITEMS_INGRESO_IDNull) return true;
			if (!this.IsITEMS_INGRESO_IDNull && !original.IsITEMS_INGRESO_IDNull)
				if (this.ITEMS_INGRESO_ID != original.ITEMS_INGRESO_ID) return true;
			if (this.IsFECHA_INGRESONull != original.IsFECHA_INGRESONull) return true;
			if (!this.IsFECHA_INGRESONull && !original.IsFECHA_INGRESONull)
				if (this.FECHA_INGRESO != original.FECHA_INGRESO) return true;
			if (this.IsFECHA_EMISIONNull != original.IsFECHA_EMISIONNull) return true;
			if (!this.IsFECHA_EMISIONNull && !original.IsFECHA_EMISIONNull)
				if (this.FECHA_EMISION != original.FECHA_EMISION) return true;
			if (this.GENERACION_CONFIRMADA != original.GENERACION_CONFIRMADA) return true;
			if (this.INGRESO_CONFIRMADO != original.INGRESO_CONFIRMADO) return true;
			if (this.NUMERO_COMPROBANTE != original.NUMERO_COMPROBANTE) return true;
			if (this.PRECINTOS != original.PRECINTOS) return true;
			if (this.IsINICIONull != original.IsINICIONull) return true;
			if (!this.IsINICIONull && !original.IsINICIONull)
				if (this.INICIO != original.INICIO) return true;
			if (this.IsFINNull != original.IsFINNull) return true;
			if (!this.IsFINNull && !original.IsFINNull)
				if (this.FIN != original.FIN) return true;
			if (this.DESPACHO != original.DESPACHO) return true;
			if (this.IDA3 != original.IDA3) return true;
			if (this.IC != original.IC) return true;
			if (this.OTROS != original.OTROS) return true;
			if (this.TRANSPORTADORA_NOMBRE != original.TRANSPORTADORA_NOMBRE) return true;
			if (this.MIC_DTA != original.MIC_DTA) return true;
			if (this.IsPESO_MANIFESTADONull != original.IsPESO_MANIFESTADONull) return true;
			if (!this.IsPESO_MANIFESTADONull && !original.IsPESO_MANIFESTADONull)
				if (this.PESO_MANIFESTADO != original.PESO_MANIFESTADO) return true;
			if (this.FCL_LCL != original.FCL_LCL) return true;
			if (this.IsFECHA_INGRESO_PUERTONull != original.IsFECHA_INGRESO_PUERTONull) return true;
			if (!this.IsFECHA_INGRESO_PUERTONull && !original.IsFECHA_INGRESO_PUERTONull)
				if (this.FECHA_INGRESO_PUERTO != original.FECHA_INGRESO_PUERTO) return true;
			if (this.CHAPA != original.CHAPA) return true;
			if (this.TIPO_CAMION_NOMBRE != original.TIPO_CAMION_NOMBRE) return true;
			if (this.CONTENEDOR_NUMERO != original.CONTENEDOR_NUMERO) return true;
			if (this.IsSEMANANull != original.IsSEMANANull) return true;
			if (!this.IsSEMANANull && !original.IsSEMANANull)
				if (this.SEMANA != original.SEMANA) return true;
			
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
		/// Gets or sets the <c>ITEMS_INGRESO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ITEMS_INGRESO_ID</c> column value.</value>
		public decimal ITEMS_INGRESO_ID
		{
			get
			{
				if(IsITEMS_INGRESO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _items_ingreso_id;
			}
			set
			{
				_items_ingreso_idNull = false;
				_items_ingreso_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ITEMS_INGRESO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsITEMS_INGRESO_IDNull
		{
			get { return _items_ingreso_idNull; }
			set { _items_ingreso_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INGRESO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INGRESO</c> column value.</value>
		public System.DateTime FECHA_INGRESO
		{
			get
			{
				if(IsFECHA_INGRESONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ingreso;
			}
			set
			{
				_fecha_ingresoNull = false;
				_fecha_ingreso = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INGRESO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INGRESONull
		{
			get { return _fecha_ingresoNull; }
			set { _fecha_ingresoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_EMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_EMISION</c> column value.</value>
		public System.DateTime FECHA_EMISION
		{
			get
			{
				if(IsFECHA_EMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_emision;
			}
			set
			{
				_fecha_emisionNull = false;
				_fecha_emision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_EMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_EMISIONNull
		{
			get { return _fecha_emisionNull; }
			set { _fecha_emisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERACION_CONFIRMADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GENERACION_CONFIRMADA</c> column value.</value>
		public string GENERACION_CONFIRMADA
		{
			get { return _generacion_confirmada; }
			set { _generacion_confirmada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INGRESO_CONFIRMADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INGRESO_CONFIRMADO</c> column value.</value>
		public string INGRESO_CONFIRMADO
		{
			get { return _ingreso_confirmado; }
			set { _ingreso_confirmado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_COMPROBANTE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_COMPROBANTE</c> column value.</value>
		public string NUMERO_COMPROBANTE
		{
			get { return _numero_comprobante; }
			set { _numero_comprobante = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PRECINTOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PRECINTOS</c> column value.</value>
		public string PRECINTOS
		{
			get { return _precintos; }
			set { _precintos = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>INICIO</c> column value.</value>
		public System.DateTime INICIO
		{
			get
			{
				if(IsINICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _inicio;
			}
			set
			{
				_inicioNull = false;
				_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsINICIONull
		{
			get { return _inicioNull; }
			set { _inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FIN</c> column value.</value>
		public System.DateTime FIN
		{
			get
			{
				if(IsFINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fin;
			}
			set
			{
				_finNull = false;
				_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFINNull
		{
			get { return _finNull; }
			set { _finNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESPACHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESPACHO</c> column value.</value>
		public string DESPACHO
		{
			get { return _despacho; }
			set { _despacho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IDA3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IDA3</c> column value.</value>
		public string IDA3
		{
			get { return _ida3; }
			set { _ida3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IC</c> column value.</value>
		public string IC
		{
			get { return _ic; }
			set { _ic = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OTROS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OTROS</c> column value.</value>
		public string OTROS
		{
			get { return _otros; }
			set { _otros = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRANSPORTADORA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSPORTADORA_NOMBRE</c> column value.</value>
		public string TRANSPORTADORA_NOMBRE
		{
			get { return _transportadora_nombre; }
			set { _transportadora_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MIC_DTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MIC_DTA</c> column value.</value>
		public string MIC_DTA
		{
			get { return _mic_dta; }
			set { _mic_dta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_MANIFESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PESO_MANIFESTADO</c> column value.</value>
		public decimal PESO_MANIFESTADO
		{
			get
			{
				if(IsPESO_MANIFESTADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _peso_manifestado;
			}
			set
			{
				_peso_manifestadoNull = false;
				_peso_manifestado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PESO_MANIFESTADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPESO_MANIFESTADONull
		{
			get { return _peso_manifestadoNull; }
			set { _peso_manifestadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FCL_LCL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FCL_LCL</c> column value.</value>
		public string FCL_LCL
		{
			get { return _fcl_lcl; }
			set { _fcl_lcl = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INGRESO_PUERTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INGRESO_PUERTO</c> column value.</value>
		public System.DateTime FECHA_INGRESO_PUERTO
		{
			get
			{
				if(IsFECHA_INGRESO_PUERTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_ingreso_puerto;
			}
			set
			{
				_fecha_ingreso_puertoNull = false;
				_fecha_ingreso_puerto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INGRESO_PUERTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INGRESO_PUERTONull
		{
			get { return _fecha_ingreso_puertoNull; }
			set { _fecha_ingreso_puertoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CHAPA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CHAPA</c> column value.</value>
		public string CHAPA
		{
			get { return _chapa; }
			set { _chapa = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_CAMION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CAMION_NOMBRE</c> column value.</value>
		public string TIPO_CAMION_NOMBRE
		{
			get { return _tipo_camion_nombre; }
			set { _tipo_camion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONTENEDOR_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONTENEDOR_NUMERO</c> column value.</value>
		public string CONTENEDOR_NUMERO
		{
			get { return _contenedor_numero; }
			set { _contenedor_numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SEMANA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SEMANA</c> column value.</value>
		public decimal SEMANA
		{
			get
			{
				if(IsSEMANANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _semana;
			}
			set
			{
				_semanaNull = false;
				_semana = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SEMANA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSEMANANull
		{
			get { return _semanaNull; }
			set { _semanaNull = value; }
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
			dynStr.Append("@CBA@ITEMS_INGRESO_ID=");
			dynStr.Append(IsITEMS_INGRESO_IDNull ? (object)"<NULL>" : ITEMS_INGRESO_ID);
			dynStr.Append("@CBA@FECHA_INGRESO=");
			dynStr.Append(IsFECHA_INGRESONull ? (object)"<NULL>" : FECHA_INGRESO);
			dynStr.Append("@CBA@FECHA_EMISION=");
			dynStr.Append(IsFECHA_EMISIONNull ? (object)"<NULL>" : FECHA_EMISION);
			dynStr.Append("@CBA@GENERACION_CONFIRMADA=");
			dynStr.Append(GENERACION_CONFIRMADA);
			dynStr.Append("@CBA@INGRESO_CONFIRMADO=");
			dynStr.Append(INGRESO_CONFIRMADO);
			dynStr.Append("@CBA@NUMERO_COMPROBANTE=");
			dynStr.Append(NUMERO_COMPROBANTE);
			dynStr.Append("@CBA@PRECINTOS=");
			dynStr.Append(PRECINTOS);
			dynStr.Append("@CBA@INICIO=");
			dynStr.Append(IsINICIONull ? (object)"<NULL>" : INICIO);
			dynStr.Append("@CBA@FIN=");
			dynStr.Append(IsFINNull ? (object)"<NULL>" : FIN);
			dynStr.Append("@CBA@DESPACHO=");
			dynStr.Append(DESPACHO);
			dynStr.Append("@CBA@IDA3=");
			dynStr.Append(IDA3);
			dynStr.Append("@CBA@IC=");
			dynStr.Append(IC);
			dynStr.Append("@CBA@OTROS=");
			dynStr.Append(OTROS);
			dynStr.Append("@CBA@TRANSPORTADORA_NOMBRE=");
			dynStr.Append(TRANSPORTADORA_NOMBRE);
			dynStr.Append("@CBA@MIC_DTA=");
			dynStr.Append(MIC_DTA);
			dynStr.Append("@CBA@PESO_MANIFESTADO=");
			dynStr.Append(IsPESO_MANIFESTADONull ? (object)"<NULL>" : PESO_MANIFESTADO);
			dynStr.Append("@CBA@FCL_LCL=");
			dynStr.Append(FCL_LCL);
			dynStr.Append("@CBA@FECHA_INGRESO_PUERTO=");
			dynStr.Append(IsFECHA_INGRESO_PUERTONull ? (object)"<NULL>" : FECHA_INGRESO_PUERTO);
			dynStr.Append("@CBA@CHAPA=");
			dynStr.Append(CHAPA);
			dynStr.Append("@CBA@TIPO_CAMION_NOMBRE=");
			dynStr.Append(TIPO_CAMION_NOMBRE);
			dynStr.Append("@CBA@CONTENEDOR_NUMERO=");
			dynStr.Append(CONTENEDOR_NUMERO);
			dynStr.Append("@CBA@SEMANA=");
			dynStr.Append(IsSEMANANull ? (object)"<NULL>" : SEMANA);
			return dynStr.ToString();
		}
	} // End of ITEMS_INGRESO_DEP_INFO_COMPLRow_Base class
} // End of namespace
