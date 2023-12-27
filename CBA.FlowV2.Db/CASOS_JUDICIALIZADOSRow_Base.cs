// <fileinfo name="CASOS_JUDICIALIZADOSRow_Base.cs">
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
	/// The base class for <see cref="CASOS_JUDICIALIZADOSRow"/> that 
	/// represents a record in the <c>CASOS_JUDICIALIZADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CASOS_JUDICIALIZADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CASOS_JUDICIALIZADOSRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private decimal _usuario_entrada_id;
		private System.DateTime _fecha_entrada;
		private decimal _motivo_entrada_id;
		private string _observacion_entrada;
		private decimal _usuario_salida_id;
		private bool _usuario_salida_idNull = true;
		private System.DateTime _fecha_salida;
		private bool _fecha_salidaNull = true;
		private decimal _motivo_salida_id;
		private bool _motivo_salida_idNull = true;
		private string _observacion_salida;

		/// <summary>
		/// Initializes a new instance of the <see cref="CASOS_JUDICIALIZADOSRow_Base"/> class.
		/// </summary>
		public CASOS_JUDICIALIZADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CASOS_JUDICIALIZADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.USUARIO_ENTRADA_ID != original.USUARIO_ENTRADA_ID) return true;
			if (this.FECHA_ENTRADA != original.FECHA_ENTRADA) return true;
			if (this.MOTIVO_ENTRADA_ID != original.MOTIVO_ENTRADA_ID) return true;
			if (this.OBSERVACION_ENTRADA != original.OBSERVACION_ENTRADA) return true;
			if (this.IsUSUARIO_SALIDA_IDNull != original.IsUSUARIO_SALIDA_IDNull) return true;
			if (!this.IsUSUARIO_SALIDA_IDNull && !original.IsUSUARIO_SALIDA_IDNull)
				if (this.USUARIO_SALIDA_ID != original.USUARIO_SALIDA_ID) return true;
			if (this.IsFECHA_SALIDANull != original.IsFECHA_SALIDANull) return true;
			if (!this.IsFECHA_SALIDANull && !original.IsFECHA_SALIDANull)
				if (this.FECHA_SALIDA != original.FECHA_SALIDA) return true;
			if (this.IsMOTIVO_SALIDA_IDNull != original.IsMOTIVO_SALIDA_IDNull) return true;
			if (!this.IsMOTIVO_SALIDA_IDNull && !original.IsMOTIVO_SALIDA_IDNull)
				if (this.MOTIVO_SALIDA_ID != original.MOTIVO_SALIDA_ID) return true;
			if (this.OBSERVACION_SALIDA != original.OBSERVACION_SALIDA) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ENTRADA_ID</c> column value.</value>
		public decimal USUARIO_ENTRADA_ID
		{
			get { return _usuario_entrada_id; }
			set { _usuario_entrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ENTRADA</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_ENTRADA</c> column value.</value>
		public System.DateTime FECHA_ENTRADA
		{
			get { return _fecha_entrada; }
			set { _fecha_entrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>MOTIVO_ENTRADA_ID</c> column value.</value>
		public decimal MOTIVO_ENTRADA_ID
		{
			get { return _motivo_entrada_id; }
			set { _motivo_entrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_ENTRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_ENTRADA</c> column value.</value>
		public string OBSERVACION_ENTRADA
		{
			get { return _observacion_entrada; }
			set { _observacion_entrada = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_SALIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_SALIDA_ID</c> column value.</value>
		public decimal USUARIO_SALIDA_ID
		{
			get
			{
				if(IsUSUARIO_SALIDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_salida_id;
			}
			set
			{
				_usuario_salida_idNull = false;
				_usuario_salida_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_SALIDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_SALIDA_IDNull
		{
			get { return _usuario_salida_idNull; }
			set { _usuario_salida_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_SALIDA</c> column value.</value>
		public System.DateTime FECHA_SALIDA
		{
			get
			{
				if(IsFECHA_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_salida;
			}
			set
			{
				_fecha_salidaNull = false;
				_fecha_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_SALIDANull
		{
			get { return _fecha_salidaNull; }
			set { _fecha_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MOTIVO_SALIDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MOTIVO_SALIDA_ID</c> column value.</value>
		public decimal MOTIVO_SALIDA_ID
		{
			get
			{
				if(IsMOTIVO_SALIDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _motivo_salida_id;
			}
			set
			{
				_motivo_salida_idNull = false;
				_motivo_salida_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MOTIVO_SALIDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMOTIVO_SALIDA_IDNull
		{
			get { return _motivo_salida_idNull; }
			set { _motivo_salida_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION_SALIDA</c> column value.</value>
		public string OBSERVACION_SALIDA
		{
			get { return _observacion_salida; }
			set { _observacion_salida = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@USUARIO_ENTRADA_ID=");
			dynStr.Append(USUARIO_ENTRADA_ID);
			dynStr.Append("@CBA@FECHA_ENTRADA=");
			dynStr.Append(FECHA_ENTRADA);
			dynStr.Append("@CBA@MOTIVO_ENTRADA_ID=");
			dynStr.Append(MOTIVO_ENTRADA_ID);
			dynStr.Append("@CBA@OBSERVACION_ENTRADA=");
			dynStr.Append(OBSERVACION_ENTRADA);
			dynStr.Append("@CBA@USUARIO_SALIDA_ID=");
			dynStr.Append(IsUSUARIO_SALIDA_IDNull ? (object)"<NULL>" : USUARIO_SALIDA_ID);
			dynStr.Append("@CBA@FECHA_SALIDA=");
			dynStr.Append(IsFECHA_SALIDANull ? (object)"<NULL>" : FECHA_SALIDA);
			dynStr.Append("@CBA@MOTIVO_SALIDA_ID=");
			dynStr.Append(IsMOTIVO_SALIDA_IDNull ? (object)"<NULL>" : MOTIVO_SALIDA_ID);
			dynStr.Append("@CBA@OBSERVACION_SALIDA=");
			dynStr.Append(OBSERVACION_SALIDA);
			return dynStr.ToString();
		}
	} // End of CASOS_JUDICIALIZADOSRow_Base class
} // End of namespace
