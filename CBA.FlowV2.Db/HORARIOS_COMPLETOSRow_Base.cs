// <fileinfo name="HORARIOS_COMPLETOSRow_Base.cs">
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
	/// The base class for <see cref="HORARIOS_COMPLETOSRow"/> that 
	/// represents a record in the <c>HORARIOS_COMPLETOS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="HORARIOS_COMPLETOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOS_COMPLETOSRow_Base
	{
		private decimal _id;
		private string _para_fecha;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private string _nombre_completo;
		private decimal _marcaciones_id;
		private bool _marcaciones_idNull = true;
		private System.DateTime _hora_inicio;
		private System.DateTime _hora_fin;
		private decimal _minutos_antes_entrada;
		private bool _minutos_antes_entradaNull = true;
		private decimal _minutos_antes_salida;
		private bool _minutos_antes_salidaNull = true;
		private decimal _minutos_despues_entrada;
		private bool _minutos_despues_entradaNull = true;
		private decimal _minutos_despues_salida;
		private bool _minutos_despues_salidaNull = true;
		private decimal _dia_id;
		private bool _dia_idNull = true;
		private decimal _turno_id;
		private decimal _nivel_asignacion;
		private bool _nivel_asignacionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_COMPLETOSRow_Base"/> class.
		/// </summary>
		public HORARIOS_COMPLETOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(HORARIOS_COMPLETOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.PARA_FECHA != original.PARA_FECHA) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.NOMBRE_COMPLETO != original.NOMBRE_COMPLETO) return true;
			if (this.IsMARCACIONES_IDNull != original.IsMARCACIONES_IDNull) return true;
			if (!this.IsMARCACIONES_IDNull && !original.IsMARCACIONES_IDNull)
				if (this.MARCACIONES_ID != original.MARCACIONES_ID) return true;
			if (this.HORA_INICIO != original.HORA_INICIO) return true;
			if (this.HORA_FIN != original.HORA_FIN) return true;
			if (this.IsMINUTOS_ANTES_ENTRADANull != original.IsMINUTOS_ANTES_ENTRADANull) return true;
			if (!this.IsMINUTOS_ANTES_ENTRADANull && !original.IsMINUTOS_ANTES_ENTRADANull)
				if (this.MINUTOS_ANTES_ENTRADA != original.MINUTOS_ANTES_ENTRADA) return true;
			if (this.IsMINUTOS_ANTES_SALIDANull != original.IsMINUTOS_ANTES_SALIDANull) return true;
			if (!this.IsMINUTOS_ANTES_SALIDANull && !original.IsMINUTOS_ANTES_SALIDANull)
				if (this.MINUTOS_ANTES_SALIDA != original.MINUTOS_ANTES_SALIDA) return true;
			if (this.IsMINUTOS_DESPUES_ENTRADANull != original.IsMINUTOS_DESPUES_ENTRADANull) return true;
			if (!this.IsMINUTOS_DESPUES_ENTRADANull && !original.IsMINUTOS_DESPUES_ENTRADANull)
				if (this.MINUTOS_DESPUES_ENTRADA != original.MINUTOS_DESPUES_ENTRADA) return true;
			if (this.IsMINUTOS_DESPUES_SALIDANull != original.IsMINUTOS_DESPUES_SALIDANull) return true;
			if (!this.IsMINUTOS_DESPUES_SALIDANull && !original.IsMINUTOS_DESPUES_SALIDANull)
				if (this.MINUTOS_DESPUES_SALIDA != original.MINUTOS_DESPUES_SALIDA) return true;
			if (this.IsDIA_IDNull != original.IsDIA_IDNull) return true;
			if (!this.IsDIA_IDNull && !original.IsDIA_IDNull)
				if (this.DIA_ID != original.DIA_ID) return true;
			if (this.TURNO_ID != original.TURNO_ID) return true;
			if (this.IsNIVEL_ASIGNACIONNull != original.IsNIVEL_ASIGNACIONNull) return true;
			if (!this.IsNIVEL_ASIGNACIONNull && !original.IsNIVEL_ASIGNACIONNull)
				if (this.NIVEL_ASIGNACION != original.NIVEL_ASIGNACION) return true;
			
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
		/// Gets or sets the <c>PARA_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PARA_FECHA</c> column value.</value>
		public string PARA_FECHA
		{
			get { return _para_fecha; }
			set { _para_fecha = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
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
		/// Gets or sets the <c>NOMBRE_COMPLETO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_COMPLETO</c> column value.</value>
		public string NOMBRE_COMPLETO
		{
			get { return _nombre_completo; }
			set { _nombre_completo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MARCACIONES_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MARCACIONES_ID</c> column value.</value>
		public decimal MARCACIONES_ID
		{
			get
			{
				if(IsMARCACIONES_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _marcaciones_id;
			}
			set
			{
				_marcaciones_idNull = false;
				_marcaciones_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MARCACIONES_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMARCACIONES_IDNull
		{
			get { return _marcaciones_idNull; }
			set { _marcaciones_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORA_INICIO</c> column value.
		/// </summary>
		/// <value>The <c>HORA_INICIO</c> column value.</value>
		public System.DateTime HORA_INICIO
		{
			get { return _hora_inicio; }
			set { _hora_inicio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORA_FIN</c> column value.
		/// </summary>
		/// <value>The <c>HORA_FIN</c> column value.</value>
		public System.DateTime HORA_FIN
		{
			get { return _hora_fin; }
			set { _hora_fin = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MINUTOS_ANTES_ENTRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MINUTOS_ANTES_ENTRADA</c> column value.</value>
		public decimal MINUTOS_ANTES_ENTRADA
		{
			get
			{
				if(IsMINUTOS_ANTES_ENTRADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _minutos_antes_entrada;
			}
			set
			{
				_minutos_antes_entradaNull = false;
				_minutos_antes_entrada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MINUTOS_ANTES_ENTRADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMINUTOS_ANTES_ENTRADANull
		{
			get { return _minutos_antes_entradaNull; }
			set { _minutos_antes_entradaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MINUTOS_ANTES_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MINUTOS_ANTES_SALIDA</c> column value.</value>
		public decimal MINUTOS_ANTES_SALIDA
		{
			get
			{
				if(IsMINUTOS_ANTES_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _minutos_antes_salida;
			}
			set
			{
				_minutos_antes_salidaNull = false;
				_minutos_antes_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MINUTOS_ANTES_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMINUTOS_ANTES_SALIDANull
		{
			get { return _minutos_antes_salidaNull; }
			set { _minutos_antes_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MINUTOS_DESPUES_ENTRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MINUTOS_DESPUES_ENTRADA</c> column value.</value>
		public decimal MINUTOS_DESPUES_ENTRADA
		{
			get
			{
				if(IsMINUTOS_DESPUES_ENTRADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _minutos_despues_entrada;
			}
			set
			{
				_minutos_despues_entradaNull = false;
				_minutos_despues_entrada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MINUTOS_DESPUES_ENTRADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMINUTOS_DESPUES_ENTRADANull
		{
			get { return _minutos_despues_entradaNull; }
			set { _minutos_despues_entradaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MINUTOS_DESPUES_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MINUTOS_DESPUES_SALIDA</c> column value.</value>
		public decimal MINUTOS_DESPUES_SALIDA
		{
			get
			{
				if(IsMINUTOS_DESPUES_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _minutos_despues_salida;
			}
			set
			{
				_minutos_despues_salidaNull = false;
				_minutos_despues_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MINUTOS_DESPUES_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMINUTOS_DESPUES_SALIDANull
		{
			get { return _minutos_despues_salidaNull; }
			set { _minutos_despues_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIA_ID</c> column value.</value>
		public decimal DIA_ID
		{
			get
			{
				if(IsDIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dia_id;
			}
			set
			{
				_dia_idNull = false;
				_dia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIA_IDNull
		{
			get { return _dia_idNull; }
			set { _dia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TURNO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TURNO_ID</c> column value.</value>
		public decimal TURNO_ID
		{
			get { return _turno_id; }
			set { _turno_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NIVEL_ASIGNACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NIVEL_ASIGNACION</c> column value.</value>
		public decimal NIVEL_ASIGNACION
		{
			get
			{
				if(IsNIVEL_ASIGNACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _nivel_asignacion;
			}
			set
			{
				_nivel_asignacionNull = false;
				_nivel_asignacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="NIVEL_ASIGNACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsNIVEL_ASIGNACIONNull
		{
			get { return _nivel_asignacionNull; }
			set { _nivel_asignacionNull = value; }
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
			dynStr.Append("@CBA@PARA_FECHA=");
			dynStr.Append(PARA_FECHA);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@NOMBRE_COMPLETO=");
			dynStr.Append(NOMBRE_COMPLETO);
			dynStr.Append("@CBA@MARCACIONES_ID=");
			dynStr.Append(IsMARCACIONES_IDNull ? (object)"<NULL>" : MARCACIONES_ID);
			dynStr.Append("@CBA@HORA_INICIO=");
			dynStr.Append(HORA_INICIO);
			dynStr.Append("@CBA@HORA_FIN=");
			dynStr.Append(HORA_FIN);
			dynStr.Append("@CBA@MINUTOS_ANTES_ENTRADA=");
			dynStr.Append(IsMINUTOS_ANTES_ENTRADANull ? (object)"<NULL>" : MINUTOS_ANTES_ENTRADA);
			dynStr.Append("@CBA@MINUTOS_ANTES_SALIDA=");
			dynStr.Append(IsMINUTOS_ANTES_SALIDANull ? (object)"<NULL>" : MINUTOS_ANTES_SALIDA);
			dynStr.Append("@CBA@MINUTOS_DESPUES_ENTRADA=");
			dynStr.Append(IsMINUTOS_DESPUES_ENTRADANull ? (object)"<NULL>" : MINUTOS_DESPUES_ENTRADA);
			dynStr.Append("@CBA@MINUTOS_DESPUES_SALIDA=");
			dynStr.Append(IsMINUTOS_DESPUES_SALIDANull ? (object)"<NULL>" : MINUTOS_DESPUES_SALIDA);
			dynStr.Append("@CBA@DIA_ID=");
			dynStr.Append(IsDIA_IDNull ? (object)"<NULL>" : DIA_ID);
			dynStr.Append("@CBA@TURNO_ID=");
			dynStr.Append(TURNO_ID);
			dynStr.Append("@CBA@NIVEL_ASIGNACION=");
			dynStr.Append(IsNIVEL_ASIGNACIONNull ? (object)"<NULL>" : NIVEL_ASIGNACION);
			return dynStr.ToString();
		}
	} // End of HORARIOS_COMPLETOSRow_Base class
} // End of namespace
