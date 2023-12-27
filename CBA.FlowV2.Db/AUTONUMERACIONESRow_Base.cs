// <fileinfo name="AUTONUMERACIONESRow_Base.cs">
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
	/// The base class for <see cref="AUTONUMERACIONESRow"/> that 
	/// represents a record in the <c>AUTONUMERACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="AUTONUMERACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class AUTONUMERACIONESRow_Base
	{
		private decimal _id;
		private decimal _tipo_autonumeracion_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private decimal _entidad_id;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private string _tabla_id;
		private decimal _limite_inferior;
		private decimal _limite_superior;
		private decimal _numero_actual;
		private string _prefijo;
		private string _sufijo;
		private System.DateTime _vencimiento;
		private bool _vencimientoNull = true;
		private string _numero_timbrado;
		private decimal _ctacte_bancaria_id;
		private bool _ctacte_bancaria_idNull = true;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_creacion;
		private System.DateTime _fecha_agoto_numeracion;
		private bool _fecha_agoto_numeracionNull = true;
		private string _estado;
		private string _tipo_generacion;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private string _imprimible;
		private string _codigo;
		private decimal _cantidad_caracteres;
		private decimal _autonumeracion_siguiente_id;
		private bool _autonumeracion_siguiente_idNull = true;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private string _funcionario_uso_exclusivo;
		private decimal _impresion_delta_altura;
		private decimal _detalles_cantidad_maxima;
		private bool _detalles_cantidad_maximaNull = true;
		private decimal _impresion_delta_ancho;
		private string _electronico;
		private decimal _articulos_familia_id;
		private bool _articulos_familia_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="AUTONUMERACIONESRow_Base"/> class.
		/// </summary>
		public AUTONUMERACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(AUTONUMERACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_AUTONUMERACION_ID != original.TIPO_AUTONUMERACION_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.LIMITE_INFERIOR != original.LIMITE_INFERIOR) return true;
			if (this.LIMITE_SUPERIOR != original.LIMITE_SUPERIOR) return true;
			if (this.NUMERO_ACTUAL != original.NUMERO_ACTUAL) return true;
			if (this.PREFIJO != original.PREFIJO) return true;
			if (this.SUFIJO != original.SUFIJO) return true;
			if (this.IsVENCIMIENTONull != original.IsVENCIMIENTONull) return true;
			if (!this.IsVENCIMIENTONull && !original.IsVENCIMIENTONull)
				if (this.VENCIMIENTO != original.VENCIMIENTO) return true;
			if (this.NUMERO_TIMBRADO != original.NUMERO_TIMBRADO) return true;
			if (this.IsCTACTE_BANCARIA_IDNull != original.IsCTACTE_BANCARIA_IDNull) return true;
			if (!this.IsCTACTE_BANCARIA_IDNull && !original.IsCTACTE_BANCARIA_IDNull)
				if (this.CTACTE_BANCARIA_ID != original.CTACTE_BANCARIA_ID) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsFECHA_AGOTO_NUMERACIONNull != original.IsFECHA_AGOTO_NUMERACIONNull) return true;
			if (!this.IsFECHA_AGOTO_NUMERACIONNull && !original.IsFECHA_AGOTO_NUMERACIONNull)
				if (this.FECHA_AGOTO_NUMERACION != original.FECHA_AGOTO_NUMERACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.TIPO_GENERACION != original.TIPO_GENERACION) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IMPRIMIBLE != original.IMPRIMIBLE) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.CANTIDAD_CARACTERES != original.CANTIDAD_CARACTERES) return true;
			if (this.IsAUTONUMERACION_SIGUIENTE_IDNull != original.IsAUTONUMERACION_SIGUIENTE_IDNull) return true;
			if (!this.IsAUTONUMERACION_SIGUIENTE_IDNull && !original.IsAUTONUMERACION_SIGUIENTE_IDNull)
				if (this.AUTONUMERACION_SIGUIENTE_ID != original.AUTONUMERACION_SIGUIENTE_ID) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.FUNCIONARIO_USO_EXCLUSIVO != original.FUNCIONARIO_USO_EXCLUSIVO) return true;
			if (this.IMPRESION_DELTA_ALTURA != original.IMPRESION_DELTA_ALTURA) return true;
			if (this.IsDETALLES_CANTIDAD_MAXIMANull != original.IsDETALLES_CANTIDAD_MAXIMANull) return true;
			if (!this.IsDETALLES_CANTIDAD_MAXIMANull && !original.IsDETALLES_CANTIDAD_MAXIMANull)
				if (this.DETALLES_CANTIDAD_MAXIMA != original.DETALLES_CANTIDAD_MAXIMA) return true;
			if (this.IMPRESION_DELTA_ANCHO != original.IMPRESION_DELTA_ANCHO) return true;
			if (this.ELECTRONICO != original.ELECTRONICO) return true;
			if (this.IsARTICULOS_FAMILIA_IDNull != original.IsARTICULOS_FAMILIA_IDNull) return true;
			if (!this.IsARTICULOS_FAMILIA_IDNull && !original.IsARTICULOS_FAMILIA_IDNull)
				if (this.ARTICULOS_FAMILIA_ID != original.ARTICULOS_FAMILIA_ID) return true;
			
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
		/// Gets or sets the <c>TIPO_AUTONUMERACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_AUTONUMERACION_ID</c> column value.</value>
		public decimal TIPO_AUTONUMERACION_ID
		{
			get { return _tipo_autonumeracion_id; }
			set { _tipo_autonumeracion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get
			{
				if(IsFLUJO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _flujo_id;
			}
			set
			{
				_flujo_idNull = false;
				_flujo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FLUJO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFLUJO_IDNull
		{
			get { return _flujo_idNull; }
			set { _flujo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_INFERIOR</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_INFERIOR</c> column value.</value>
		public decimal LIMITE_INFERIOR
		{
			get { return _limite_inferior; }
			set { _limite_inferior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_SUPERIOR</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_SUPERIOR</c> column value.</value>
		public decimal LIMITE_SUPERIOR
		{
			get { return _limite_superior; }
			set { _limite_superior = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_ACTUAL</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO_ACTUAL</c> column value.</value>
		public decimal NUMERO_ACTUAL
		{
			get { return _numero_actual; }
			set { _numero_actual = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PREFIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PREFIJO</c> column value.</value>
		public string PREFIJO
		{
			get { return _prefijo; }
			set { _prefijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUFIJO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUFIJO</c> column value.</value>
		public string SUFIJO
		{
			get { return _sufijo; }
			set { _sufijo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VENCIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VENCIMIENTO</c> column value.</value>
		public System.DateTime VENCIMIENTO
		{
			get
			{
				if(IsVENCIMIENTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _vencimiento;
			}
			set
			{
				_vencimientoNull = false;
				_vencimiento = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VENCIMIENTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVENCIMIENTONull
		{
			get { return _vencimientoNull; }
			set { _vencimientoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_TIMBRADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_TIMBRADO</c> column value.</value>
		public string NUMERO_TIMBRADO
		{
			get { return _numero_timbrado; }
			set { _numero_timbrado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTACTE_BANCARIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTACTE_BANCARIA_ID</c> column value.</value>
		public decimal CTACTE_BANCARIA_ID
		{
			get
			{
				if(IsCTACTE_BANCARIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctacte_bancaria_id;
			}
			set
			{
				_ctacte_bancaria_idNull = false;
				_ctacte_bancaria_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTACTE_BANCARIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTACTE_BANCARIA_IDNull
		{
			get { return _ctacte_bancaria_idNull; }
			set { _ctacte_bancaria_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_CREACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_ID</c> column value.</value>
		public decimal USUARIO_CREACION_ID
		{
			get { return _usuario_creacion_id; }
			set { _usuario_creacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_CREACION</c> column value.</value>
		public System.DateTime FECHA_CREACION
		{
			get { return _fecha_creacion; }
			set { _fecha_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_AGOTO_NUMERACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_AGOTO_NUMERACION</c> column value.</value>
		public System.DateTime FECHA_AGOTO_NUMERACION
		{
			get
			{
				if(IsFECHA_AGOTO_NUMERACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_agoto_numeracion;
			}
			set
			{
				_fecha_agoto_numeracionNull = false;
				_fecha_agoto_numeracion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_AGOTO_NUMERACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_AGOTO_NUMERACIONNull
		{
			get { return _fecha_agoto_numeracionNull; }
			set { _fecha_agoto_numeracionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_GENERACION</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_GENERACION</c> column value.</value>
		public string TIPO_GENERACION
		{
			get { return _tipo_generacion; }
			set { _tipo_generacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRIMIBLE</c> column value.
		/// </summary>
		/// <value>The <c>IMPRIMIBLE</c> column value.</value>
		public string IMPRIMIBLE
		{
			get { return _imprimible; }
			set { _imprimible = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_CARACTERES</c> column value.
		/// </summary>
		/// <value>The <c>CANTIDAD_CARACTERES</c> column value.</value>
		public decimal CANTIDAD_CARACTERES
		{
			get { return _cantidad_caracteres; }
			set { _cantidad_caracteres = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>AUTONUMERACION_SIGUIENTE_ID</c> column value.</value>
		public decimal AUTONUMERACION_SIGUIENTE_ID
		{
			get
			{
				if(IsAUTONUMERACION_SIGUIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _autonumeracion_siguiente_id;
			}
			set
			{
				_autonumeracion_siguiente_idNull = false;
				_autonumeracion_siguiente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="AUTONUMERACION_SIGUIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsAUTONUMERACION_SIGUIENTE_IDNull
		{
			get { return _autonumeracion_siguiente_idNull; }
			set { _autonumeracion_siguiente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_USO_EXCLUSIVO</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_USO_EXCLUSIVO</c> column value.</value>
		public string FUNCIONARIO_USO_EXCLUSIVO
		{
			get { return _funcionario_uso_exclusivo; }
			set { _funcionario_uso_exclusivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESION_DELTA_ALTURA</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESION_DELTA_ALTURA</c> column value.</value>
		public decimal IMPRESION_DELTA_ALTURA
		{
			get { return _impresion_delta_altura; }
			set { _impresion_delta_altura = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DETALLES_CANTIDAD_MAXIMA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DETALLES_CANTIDAD_MAXIMA</c> column value.</value>
		public decimal DETALLES_CANTIDAD_MAXIMA
		{
			get
			{
				if(IsDETALLES_CANTIDAD_MAXIMANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _detalles_cantidad_maxima;
			}
			set
			{
				_detalles_cantidad_maximaNull = false;
				_detalles_cantidad_maxima = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DETALLES_CANTIDAD_MAXIMA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDETALLES_CANTIDAD_MAXIMANull
		{
			get { return _detalles_cantidad_maximaNull; }
			set { _detalles_cantidad_maximaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IMPRESION_DELTA_ANCHO</c> column value.
		/// </summary>
		/// <value>The <c>IMPRESION_DELTA_ANCHO</c> column value.</value>
		public decimal IMPRESION_DELTA_ANCHO
		{
			get { return _impresion_delta_ancho; }
			set { _impresion_delta_ancho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ELECTRONICO</c> column value.
		/// </summary>
		/// <value>The <c>ELECTRONICO</c> column value.</value>
		public string ELECTRONICO
		{
			get { return _electronico; }
			set { _electronico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULOS_FAMILIA_ID</c> column value.</value>
		public decimal ARTICULOS_FAMILIA_ID
		{
			get
			{
				if(IsARTICULOS_FAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulos_familia_id;
			}
			set
			{
				_articulos_familia_idNull = false;
				_articulos_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULOS_FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULOS_FAMILIA_IDNull
		{
			get { return _articulos_familia_idNull; }
			set { _articulos_familia_idNull = value; }
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
			dynStr.Append("@CBA@TIPO_AUTONUMERACION_ID=");
			dynStr.Append(TIPO_AUTONUMERACION_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@LIMITE_INFERIOR=");
			dynStr.Append(LIMITE_INFERIOR);
			dynStr.Append("@CBA@LIMITE_SUPERIOR=");
			dynStr.Append(LIMITE_SUPERIOR);
			dynStr.Append("@CBA@NUMERO_ACTUAL=");
			dynStr.Append(NUMERO_ACTUAL);
			dynStr.Append("@CBA@PREFIJO=");
			dynStr.Append(PREFIJO);
			dynStr.Append("@CBA@SUFIJO=");
			dynStr.Append(SUFIJO);
			dynStr.Append("@CBA@VENCIMIENTO=");
			dynStr.Append(IsVENCIMIENTONull ? (object)"<NULL>" : VENCIMIENTO);
			dynStr.Append("@CBA@NUMERO_TIMBRADO=");
			dynStr.Append(NUMERO_TIMBRADO);
			dynStr.Append("@CBA@CTACTE_BANCARIA_ID=");
			dynStr.Append(IsCTACTE_BANCARIA_IDNull ? (object)"<NULL>" : CTACTE_BANCARIA_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@FECHA_AGOTO_NUMERACION=");
			dynStr.Append(IsFECHA_AGOTO_NUMERACIONNull ? (object)"<NULL>" : FECHA_AGOTO_NUMERACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO_GENERACION=");
			dynStr.Append(TIPO_GENERACION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@IMPRIMIBLE=");
			dynStr.Append(IMPRIMIBLE);
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@CANTIDAD_CARACTERES=");
			dynStr.Append(CANTIDAD_CARACTERES);
			dynStr.Append("@CBA@AUTONUMERACION_SIGUIENTE_ID=");
			dynStr.Append(IsAUTONUMERACION_SIGUIENTE_IDNull ? (object)"<NULL>" : AUTONUMERACION_SIGUIENTE_ID);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FUNCIONARIO_USO_EXCLUSIVO=");
			dynStr.Append(FUNCIONARIO_USO_EXCLUSIVO);
			dynStr.Append("@CBA@IMPRESION_DELTA_ALTURA=");
			dynStr.Append(IMPRESION_DELTA_ALTURA);
			dynStr.Append("@CBA@DETALLES_CANTIDAD_MAXIMA=");
			dynStr.Append(IsDETALLES_CANTIDAD_MAXIMANull ? (object)"<NULL>" : DETALLES_CANTIDAD_MAXIMA);
			dynStr.Append("@CBA@IMPRESION_DELTA_ANCHO=");
			dynStr.Append(IMPRESION_DELTA_ANCHO);
			dynStr.Append("@CBA@ELECTRONICO=");
			dynStr.Append(ELECTRONICO);
			dynStr.Append("@CBA@ARTICULOS_FAMILIA_ID=");
			dynStr.Append(IsARTICULOS_FAMILIA_IDNull ? (object)"<NULL>" : ARTICULOS_FAMILIA_ID);
			return dynStr.ToString();
		}
	} // End of AUTONUMERACIONESRow_Base class
} // End of namespace
