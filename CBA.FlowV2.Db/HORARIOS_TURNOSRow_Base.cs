// <fileinfo name="HORARIOS_TURNOSRow_Base.cs">
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
	/// The base class for <see cref="HORARIOS_TURNOSRow"/> that 
	/// represents a record in the <c>HORARIOS_TURNOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="HORARIOS_TURNOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOS_TURNOSRow_Base
	{
		private decimal _id;
		private decimal _horario_id;
		private string _nombre;
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

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOS_TURNOSRow_Base"/> class.
		/// </summary>
		public HORARIOS_TURNOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(HORARIOS_TURNOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.HORARIO_ID != original.HORARIO_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
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
		/// Gets or sets the <c>HORARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>HORARIO_ID</c> column value.</value>
		public decimal HORARIO_ID
		{
			get { return _horario_id; }
			set { _horario_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@HORARIO_ID=");
			dynStr.Append(HORARIO_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
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
			return dynStr.ToString();
		}
	} // End of HORARIOS_TURNOSRow_Base class
} // End of namespace
