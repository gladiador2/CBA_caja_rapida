// <fileinfo name="TRAMIT_MEDIDAS_CAUT_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/> that 
	/// represents a record in the <c>TRAMIT_MEDIDAS_CAUT_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMIT_MEDIDAS_CAUT_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _texto_predefinido_id_tipo;
		private string _tipo_texto_predef_nombre_tipo;
		private string _texto_predef_tipo;
		private string _observacion;
		private decimal _tramite_id;
		private decimal _tramite_tipo_id;
		private string _tramite_tipo_nombre;
		private string _titulo;
		private System.DateTime _fecha_otorgamiento;
		private bool _fecha_otorgamientoNull = true;
		private System.DateTime _fecha_inscripcion;
		private decimal _monto_embargado;
		private bool _monto_embargadoNull = true;
		private string _nro_cuenta_bancaria;
		private string _entidad;
		private string _cuenta;
		private decimal _texto_predefinido_id_bien;
		private bool _texto_predefinido_id_bienNull = true;
		private string _tipo_texto_predef_nombre_bien;
		private string _texto_predef_bien;
		private string _datos_del_bien;
		private string _otros_embargos_bien;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMIT_MEDIDAS_CAUT_INF_COMPRow_Base"/> class.
		/// </summary>
		public TRAMIT_MEDIDAS_CAUT_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMIT_MEDIDAS_CAUT_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TEXTO_PREDEFINIDO_ID_TIPO != original.TEXTO_PREDEFINIDO_ID_TIPO) return true;
			if (this.TIPO_TEXTO_PREDEF_NOMBRE_TIPO != original.TIPO_TEXTO_PREDEF_NOMBRE_TIPO) return true;
			if (this.TEXTO_PREDEF_TIPO != original.TEXTO_PREDEF_TIPO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.TRAMITE_ID != original.TRAMITE_ID) return true;
			if (this.TRAMITE_TIPO_ID != original.TRAMITE_TIPO_ID) return true;
			if (this.TRAMITE_TIPO_NOMBRE != original.TRAMITE_TIPO_NOMBRE) return true;
			if (this.TITULO != original.TITULO) return true;
			if (this.IsFECHA_OTORGAMIENTONull != original.IsFECHA_OTORGAMIENTONull) return true;
			if (!this.IsFECHA_OTORGAMIENTONull && !original.IsFECHA_OTORGAMIENTONull)
				if (this.FECHA_OTORGAMIENTO != original.FECHA_OTORGAMIENTO) return true;
			if (this.FECHA_INSCRIPCION != original.FECHA_INSCRIPCION) return true;
			if (this.IsMONTO_EMBARGADONull != original.IsMONTO_EMBARGADONull) return true;
			if (!this.IsMONTO_EMBARGADONull && !original.IsMONTO_EMBARGADONull)
				if (this.MONTO_EMBARGADO != original.MONTO_EMBARGADO) return true;
			if (this.NRO_CUENTA_BANCARIA != original.NRO_CUENTA_BANCARIA) return true;
			if (this.ENTIDAD != original.ENTIDAD) return true;
			if (this.CUENTA != original.CUENTA) return true;
			if (this.IsTEXTO_PREDEFINIDO_ID_BIENNull != original.IsTEXTO_PREDEFINIDO_ID_BIENNull) return true;
			if (!this.IsTEXTO_PREDEFINIDO_ID_BIENNull && !original.IsTEXTO_PREDEFINIDO_ID_BIENNull)
				if (this.TEXTO_PREDEFINIDO_ID_BIEN != original.TEXTO_PREDEFINIDO_ID_BIEN) return true;
			if (this.TIPO_TEXTO_PREDEF_NOMBRE_BIEN != original.TIPO_TEXTO_PREDEF_NOMBRE_BIEN) return true;
			if (this.TEXTO_PREDEF_BIEN != original.TEXTO_PREDEF_BIEN) return true;
			if (this.DATOS_DEL_BIEN != original.DATOS_DEL_BIEN) return true;
			if (this.OTROS_EMBARGOS_BIEN != original.OTROS_EMBARGOS_BIEN) return true;
			
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
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID_TIPO</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID_TIPO</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID_TIPO
		{
			get { return _texto_predefinido_id_tipo; }
			set { _texto_predefinido_id_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEF_NOMBRE_TIPO</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEF_NOMBRE_TIPO</c> column value.</value>
		public string TIPO_TEXTO_PREDEF_NOMBRE_TIPO
		{
			get { return _tipo_texto_predef_nombre_tipo; }
			set { _tipo_texto_predef_nombre_tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_TIPO</c> column value.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_TIPO</c> column value.</value>
		public string TEXTO_PREDEF_TIPO
		{
			get { return _texto_predef_tipo; }
			set { _texto_predef_tipo = value; }
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
		/// Gets or sets the <c>TRAMITE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_ID</c> column value.</value>
		public decimal TRAMITE_ID
		{
			get { return _tramite_id; }
			set { _tramite_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ID
		{
			get { return _tramite_tipo_id; }
			set { _tramite_tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_NOMBRE
		{
			get { return _tramite_tipo_nombre; }
			set { _tramite_tipo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TITULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TITULO</c> column value.</value>
		public string TITULO
		{
			get { return _titulo; }
			set { _titulo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_OTORGAMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_OTORGAMIENTO</c> column value.</value>
		public System.DateTime FECHA_OTORGAMIENTO
		{
			get
			{
				if(IsFECHA_OTORGAMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_otorgamiento;
			}
			set
			{
				_fecha_otorgamientoNull = false;
				_fecha_otorgamiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_OTORGAMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_OTORGAMIENTONull
		{
			get { return _fecha_otorgamientoNull; }
			set { _fecha_otorgamientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INSCRIPCION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_INSCRIPCION</c> column value.</value>
		public System.DateTime FECHA_INSCRIPCION
		{
			get { return _fecha_inscripcion; }
			set { _fecha_inscripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_EMBARGADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_EMBARGADO</c> column value.</value>
		public decimal MONTO_EMBARGADO
		{
			get
			{
				if(IsMONTO_EMBARGADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_embargado;
			}
			set
			{
				_monto_embargadoNull = false;
				_monto_embargado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_EMBARGADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_EMBARGADONull
		{
			get { return _monto_embargadoNull; }
			set { _monto_embargadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NRO_CUENTA_BANCARIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NRO_CUENTA_BANCARIA</c> column value.</value>
		public string NRO_CUENTA_BANCARIA
		{
			get { return _nro_cuenta_bancaria; }
			set { _nro_cuenta_bancaria = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTIDAD</c> column value.</value>
		public string ENTIDAD
		{
			get { return _entidad; }
			set { _entidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CUENTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CUENTA</c> column value.</value>
		public string CUENTA
		{
			get { return _cuenta; }
			set { _cuenta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEFINIDO_ID_BIEN</c> column value.</value>
		public decimal TEXTO_PREDEFINIDO_ID_BIEN
		{
			get
			{
				if(IsTEXTO_PREDEFINIDO_ID_BIENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _texto_predefinido_id_bien;
			}
			set
			{
				_texto_predefinido_id_bienNull = false;
				_texto_predefinido_id_bien = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TEXTO_PREDEFINIDO_ID_BIEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTEXTO_PREDEFINIDO_ID_BIENNull
		{
			get { return _texto_predefinido_id_bienNull; }
			set { _texto_predefinido_id_bienNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEF_NOMBRE_BIEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEF_NOMBRE_BIEN</c> column value.</value>
		public string TIPO_TEXTO_PREDEF_NOMBRE_BIEN
		{
			get { return _tipo_texto_predef_nombre_bien; }
			set { _tipo_texto_predef_nombre_bien = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TEXTO_PREDEF_BIEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TEXTO_PREDEF_BIEN</c> column value.</value>
		public string TEXTO_PREDEF_BIEN
		{
			get { return _texto_predef_bien; }
			set { _texto_predef_bien = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DATOS_DEL_BIEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DATOS_DEL_BIEN</c> column value.</value>
		public string DATOS_DEL_BIEN
		{
			get { return _datos_del_bien; }
			set { _datos_del_bien = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OTROS_EMBARGOS_BIEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OTROS_EMBARGOS_BIEN</c> column value.</value>
		public string OTROS_EMBARGOS_BIEN
		{
			get { return _otros_embargos_bien; }
			set { _otros_embargos_bien = value; }
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
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID_TIPO=");
			dynStr.Append(TEXTO_PREDEFINIDO_ID_TIPO);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEF_NOMBRE_TIPO=");
			dynStr.Append(TIPO_TEXTO_PREDEF_NOMBRE_TIPO);
			dynStr.Append("@CBA@TEXTO_PREDEF_TIPO=");
			dynStr.Append(TEXTO_PREDEF_TIPO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TRAMITE_ID=");
			dynStr.Append(TRAMITE_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_ID=");
			dynStr.Append(TRAMITE_TIPO_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_NOMBRE);
			dynStr.Append("@CBA@TITULO=");
			dynStr.Append(TITULO);
			dynStr.Append("@CBA@FECHA_OTORGAMIENTO=");
			dynStr.Append(IsFECHA_OTORGAMIENTONull ? (object)"<NULL>" : FECHA_OTORGAMIENTO);
			dynStr.Append("@CBA@FECHA_INSCRIPCION=");
			dynStr.Append(FECHA_INSCRIPCION);
			dynStr.Append("@CBA@MONTO_EMBARGADO=");
			dynStr.Append(IsMONTO_EMBARGADONull ? (object)"<NULL>" : MONTO_EMBARGADO);
			dynStr.Append("@CBA@NRO_CUENTA_BANCARIA=");
			dynStr.Append(NRO_CUENTA_BANCARIA);
			dynStr.Append("@CBA@ENTIDAD=");
			dynStr.Append(ENTIDAD);
			dynStr.Append("@CBA@CUENTA=");
			dynStr.Append(CUENTA);
			dynStr.Append("@CBA@TEXTO_PREDEFINIDO_ID_BIEN=");
			dynStr.Append(IsTEXTO_PREDEFINIDO_ID_BIENNull ? (object)"<NULL>" : TEXTO_PREDEFINIDO_ID_BIEN);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEF_NOMBRE_BIEN=");
			dynStr.Append(TIPO_TEXTO_PREDEF_NOMBRE_BIEN);
			dynStr.Append("@CBA@TEXTO_PREDEF_BIEN=");
			dynStr.Append(TEXTO_PREDEF_BIEN);
			dynStr.Append("@CBA@DATOS_DEL_BIEN=");
			dynStr.Append(DATOS_DEL_BIEN);
			dynStr.Append("@CBA@OTROS_EMBARGOS_BIEN=");
			dynStr.Append(OTROS_EMBARGOS_BIEN);
			return dynStr.ToString();
		}
	} // End of TRAMIT_MEDIDAS_CAUT_INF_COMPRow_Base class
} // End of namespace
