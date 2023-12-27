// <fileinfo name="MARCACIONESRow_Base.cs">
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
	/// The base class for <see cref="MARCACIONESRow"/> that 
	/// represents a record in the <c>MARCACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MARCACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MARCACIONESRow_Base
	{
		private decimal _reloj_marcacion_id;
		private bool _reloj_marcacion_idNull = true;
		private decimal _reloj_funcionario_id;
		private bool _reloj_funcionario_idNull = true;
		private System.DateTime _fecha_marcacion;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _calificacion;
		private bool _calificacionNull = true;
		private string _es_copiado;
		private string _justificado;
		private string _observacion;
		private string _tipo_movimiento;
		private System.DateTime _fecha_copiado;
		private bool _fecha_copiadoNull = true;
		private string _descontar;
		private string _descontado;
		private decimal _id;
		private System.DateTime _turno_entrada_antes;
		private bool _turno_entrada_antesNull = true;
		private System.DateTime _turno_entrada;
		private bool _turno_entradaNull = true;
		private System.DateTime _turno_entrada_despues;
		private bool _turno_entrada_despuesNull = true;
		private System.DateTime _turno_salida_antes;
		private bool _turno_salida_antesNull = true;
		private System.DateTime _turno_salida;
		private bool _turno_salidaNull = true;
		private System.DateTime _turno_salida_despues;
		private bool _turno_salida_despuesNull = true;
		private decimal _turno_id;
		private bool _turno_idNull = true;
		private decimal _descuento_llegada_tardia_id;
		private bool _descuento_llegada_tardia_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="MARCACIONESRow_Base"/> class.
		/// </summary>
		public MARCACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MARCACIONESRow_Base original)
		{
			if (this.IsRELOJ_MARCACION_IDNull != original.IsRELOJ_MARCACION_IDNull) return true;
			if (!this.IsRELOJ_MARCACION_IDNull && !original.IsRELOJ_MARCACION_IDNull)
				if (this.RELOJ_MARCACION_ID != original.RELOJ_MARCACION_ID) return true;
			if (this.IsRELOJ_FUNCIONARIO_IDNull != original.IsRELOJ_FUNCIONARIO_IDNull) return true;
			if (!this.IsRELOJ_FUNCIONARIO_IDNull && !original.IsRELOJ_FUNCIONARIO_IDNull)
				if (this.RELOJ_FUNCIONARIO_ID != original.RELOJ_FUNCIONARIO_ID) return true;
			if (this.FECHA_MARCACION != original.FECHA_MARCACION) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsCALIFICACIONNull != original.IsCALIFICACIONNull) return true;
			if (!this.IsCALIFICACIONNull && !original.IsCALIFICACIONNull)
				if (this.CALIFICACION != original.CALIFICACION) return true;
			if (this.ES_COPIADO != original.ES_COPIADO) return true;
			if (this.JUSTIFICADO != original.JUSTIFICADO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.TIPO_MOVIMIENTO != original.TIPO_MOVIMIENTO) return true;
			if (this.IsFECHA_COPIADONull != original.IsFECHA_COPIADONull) return true;
			if (!this.IsFECHA_COPIADONull && !original.IsFECHA_COPIADONull)
				if (this.FECHA_COPIADO != original.FECHA_COPIADO) return true;
			if (this.DESCONTAR != original.DESCONTAR) return true;
			if (this.DESCONTADO != original.DESCONTADO) return true;
			if (this.ID != original.ID) return true;
			if (this.IsTURNO_ENTRADA_ANTESNull != original.IsTURNO_ENTRADA_ANTESNull) return true;
			if (!this.IsTURNO_ENTRADA_ANTESNull && !original.IsTURNO_ENTRADA_ANTESNull)
				if (this.TURNO_ENTRADA_ANTES != original.TURNO_ENTRADA_ANTES) return true;
			if (this.IsTURNO_ENTRADANull != original.IsTURNO_ENTRADANull) return true;
			if (!this.IsTURNO_ENTRADANull && !original.IsTURNO_ENTRADANull)
				if (this.TURNO_ENTRADA != original.TURNO_ENTRADA) return true;
			if (this.IsTURNO_ENTRADA_DESPUESNull != original.IsTURNO_ENTRADA_DESPUESNull) return true;
			if (!this.IsTURNO_ENTRADA_DESPUESNull && !original.IsTURNO_ENTRADA_DESPUESNull)
				if (this.TURNO_ENTRADA_DESPUES != original.TURNO_ENTRADA_DESPUES) return true;
			if (this.IsTURNO_SALIDA_ANTESNull != original.IsTURNO_SALIDA_ANTESNull) return true;
			if (!this.IsTURNO_SALIDA_ANTESNull && !original.IsTURNO_SALIDA_ANTESNull)
				if (this.TURNO_SALIDA_ANTES != original.TURNO_SALIDA_ANTES) return true;
			if (this.IsTURNO_SALIDANull != original.IsTURNO_SALIDANull) return true;
			if (!this.IsTURNO_SALIDANull && !original.IsTURNO_SALIDANull)
				if (this.TURNO_SALIDA != original.TURNO_SALIDA) return true;
			if (this.IsTURNO_SALIDA_DESPUESNull != original.IsTURNO_SALIDA_DESPUESNull) return true;
			if (!this.IsTURNO_SALIDA_DESPUESNull && !original.IsTURNO_SALIDA_DESPUESNull)
				if (this.TURNO_SALIDA_DESPUES != original.TURNO_SALIDA_DESPUES) return true;
			if (this.IsTURNO_IDNull != original.IsTURNO_IDNull) return true;
			if (!this.IsTURNO_IDNull && !original.IsTURNO_IDNull)
				if (this.TURNO_ID != original.TURNO_ID) return true;
			if (this.IsDESCUENTO_LLEGADA_TARDIA_IDNull != original.IsDESCUENTO_LLEGADA_TARDIA_IDNull) return true;
			if (!this.IsDESCUENTO_LLEGADA_TARDIA_IDNull && !original.IsDESCUENTO_LLEGADA_TARDIA_IDNull)
				if (this.DESCUENTO_LLEGADA_TARDIA_ID != original.DESCUENTO_LLEGADA_TARDIA_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>RELOJ_MARCACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RELOJ_MARCACION_ID</c> column value.</value>
		public decimal RELOJ_MARCACION_ID
		{
			get
			{
				if(IsRELOJ_MARCACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reloj_marcacion_id;
			}
			set
			{
				_reloj_marcacion_idNull = false;
				_reloj_marcacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RELOJ_MARCACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRELOJ_MARCACION_IDNull
		{
			get { return _reloj_marcacion_idNull; }
			set { _reloj_marcacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RELOJ_FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RELOJ_FUNCIONARIO_ID</c> column value.</value>
		public decimal RELOJ_FUNCIONARIO_ID
		{
			get
			{
				if(IsRELOJ_FUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _reloj_funcionario_id;
			}
			set
			{
				_reloj_funcionario_idNull = false;
				_reloj_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="RELOJ_FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsRELOJ_FUNCIONARIO_IDNull
		{
			get { return _reloj_funcionario_idNull; }
			set { _reloj_funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_MARCACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_MARCACION</c> column value.</value>
		public System.DateTime FECHA_MARCACION
		{
			get { return _fecha_marcacion; }
			set { _fecha_marcacion = value; }
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
		/// Gets or sets the <c>CALIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALIFICACION</c> column value.</value>
		public decimal CALIFICACION
		{
			get
			{
				if(IsCALIFICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _calificacion;
			}
			set
			{
				_calificacionNull = false;
				_calificacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CALIFICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCALIFICACIONNull
		{
			get { return _calificacionNull; }
			set { _calificacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_COPIADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_COPIADO</c> column value.</value>
		public string ES_COPIADO
		{
			get { return _es_copiado; }
			set { _es_copiado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>JUSTIFICADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>JUSTIFICADO</c> column value.</value>
		public string JUSTIFICADO
		{
			get { return _justificado; }
			set { _justificado = value; }
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
		/// Gets or sets the <c>TIPO_MOVIMIENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_MOVIMIENTO</c> column value.</value>
		public string TIPO_MOVIMIENTO
		{
			get { return _tipo_movimiento; }
			set { _tipo_movimiento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_COPIADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_COPIADO</c> column value.</value>
		public System.DateTime FECHA_COPIADO
		{
			get
			{
				if(IsFECHA_COPIADONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_copiado;
			}
			set
			{
				_fecha_copiadoNull = false;
				_fecha_copiado = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_COPIADO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_COPIADONull
		{
			get { return _fecha_copiadoNull; }
			set { _fecha_copiadoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCONTAR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCONTAR</c> column value.</value>
		public string DESCONTAR
		{
			get { return _descontar; }
			set { _descontar = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCONTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCONTADO</c> column value.</value>
		public string DESCONTADO
		{
			get { return _descontado; }
			set { _descontado = value; }
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
		/// Gets or sets the <c>TURNO_ENTRADA_ANTES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TURNO_ENTRADA_ANTES</c> column value.</value>
		public System.DateTime TURNO_ENTRADA_ANTES
		{
			get
			{
				if(IsTURNO_ENTRADA_ANTESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _turno_entrada_antes;
			}
			set
			{
				_turno_entrada_antesNull = false;
				_turno_entrada_antes = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TURNO_ENTRADA_ANTES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTURNO_ENTRADA_ANTESNull
		{
			get { return _turno_entrada_antesNull; }
			set { _turno_entrada_antesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TURNO_ENTRADA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TURNO_ENTRADA</c> column value.</value>
		public System.DateTime TURNO_ENTRADA
		{
			get
			{
				if(IsTURNO_ENTRADANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _turno_entrada;
			}
			set
			{
				_turno_entradaNull = false;
				_turno_entrada = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TURNO_ENTRADA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTURNO_ENTRADANull
		{
			get { return _turno_entradaNull; }
			set { _turno_entradaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TURNO_ENTRADA_DESPUES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TURNO_ENTRADA_DESPUES</c> column value.</value>
		public System.DateTime TURNO_ENTRADA_DESPUES
		{
			get
			{
				if(IsTURNO_ENTRADA_DESPUESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _turno_entrada_despues;
			}
			set
			{
				_turno_entrada_despuesNull = false;
				_turno_entrada_despues = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TURNO_ENTRADA_DESPUES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTURNO_ENTRADA_DESPUESNull
		{
			get { return _turno_entrada_despuesNull; }
			set { _turno_entrada_despuesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TURNO_SALIDA_ANTES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TURNO_SALIDA_ANTES</c> column value.</value>
		public System.DateTime TURNO_SALIDA_ANTES
		{
			get
			{
				if(IsTURNO_SALIDA_ANTESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _turno_salida_antes;
			}
			set
			{
				_turno_salida_antesNull = false;
				_turno_salida_antes = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TURNO_SALIDA_ANTES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTURNO_SALIDA_ANTESNull
		{
			get { return _turno_salida_antesNull; }
			set { _turno_salida_antesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TURNO_SALIDA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TURNO_SALIDA</c> column value.</value>
		public System.DateTime TURNO_SALIDA
		{
			get
			{
				if(IsTURNO_SALIDANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _turno_salida;
			}
			set
			{
				_turno_salidaNull = false;
				_turno_salida = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TURNO_SALIDA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTURNO_SALIDANull
		{
			get { return _turno_salidaNull; }
			set { _turno_salidaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TURNO_SALIDA_DESPUES</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TURNO_SALIDA_DESPUES</c> column value.</value>
		public System.DateTime TURNO_SALIDA_DESPUES
		{
			get
			{
				if(IsTURNO_SALIDA_DESPUESNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _turno_salida_despues;
			}
			set
			{
				_turno_salida_despuesNull = false;
				_turno_salida_despues = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TURNO_SALIDA_DESPUES"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTURNO_SALIDA_DESPUESNull
		{
			get { return _turno_salida_despuesNull; }
			set { _turno_salida_despuesNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TURNO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TURNO_ID</c> column value.</value>
		public decimal TURNO_ID
		{
			get
			{
				if(IsTURNO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _turno_id;
			}
			set
			{
				_turno_idNull = false;
				_turno_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TURNO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTURNO_IDNull
		{
			get { return _turno_idNull; }
			set { _turno_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCUENTO_LLEGADA_TARDIA_ID</c> column value.</value>
		public decimal DESCUENTO_LLEGADA_TARDIA_ID
		{
			get
			{
				if(IsDESCUENTO_LLEGADA_TARDIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _descuento_llegada_tardia_id;
			}
			set
			{
				_descuento_llegada_tardia_idNull = false;
				_descuento_llegada_tardia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DESCUENTO_LLEGADA_TARDIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDESCUENTO_LLEGADA_TARDIA_IDNull
		{
			get { return _descuento_llegada_tardia_idNull; }
			set { _descuento_llegada_tardia_idNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@RELOJ_MARCACION_ID=");
			dynStr.Append(IsRELOJ_MARCACION_IDNull ? (object)"<NULL>" : RELOJ_MARCACION_ID);
			dynStr.Append("@CBA@RELOJ_FUNCIONARIO_ID=");
			dynStr.Append(IsRELOJ_FUNCIONARIO_IDNull ? (object)"<NULL>" : RELOJ_FUNCIONARIO_ID);
			dynStr.Append("@CBA@FECHA_MARCACION=");
			dynStr.Append(FECHA_MARCACION);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@CALIFICACION=");
			dynStr.Append(IsCALIFICACIONNull ? (object)"<NULL>" : CALIFICACION);
			dynStr.Append("@CBA@ES_COPIADO=");
			dynStr.Append(ES_COPIADO);
			dynStr.Append("@CBA@JUSTIFICADO=");
			dynStr.Append(JUSTIFICADO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@TIPO_MOVIMIENTO=");
			dynStr.Append(TIPO_MOVIMIENTO);
			dynStr.Append("@CBA@FECHA_COPIADO=");
			dynStr.Append(IsFECHA_COPIADONull ? (object)"<NULL>" : FECHA_COPIADO);
			dynStr.Append("@CBA@DESCONTAR=");
			dynStr.Append(DESCONTAR);
			dynStr.Append("@CBA@DESCONTADO=");
			dynStr.Append(DESCONTADO);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TURNO_ENTRADA_ANTES=");
			dynStr.Append(IsTURNO_ENTRADA_ANTESNull ? (object)"<NULL>" : TURNO_ENTRADA_ANTES);
			dynStr.Append("@CBA@TURNO_ENTRADA=");
			dynStr.Append(IsTURNO_ENTRADANull ? (object)"<NULL>" : TURNO_ENTRADA);
			dynStr.Append("@CBA@TURNO_ENTRADA_DESPUES=");
			dynStr.Append(IsTURNO_ENTRADA_DESPUESNull ? (object)"<NULL>" : TURNO_ENTRADA_DESPUES);
			dynStr.Append("@CBA@TURNO_SALIDA_ANTES=");
			dynStr.Append(IsTURNO_SALIDA_ANTESNull ? (object)"<NULL>" : TURNO_SALIDA_ANTES);
			dynStr.Append("@CBA@TURNO_SALIDA=");
			dynStr.Append(IsTURNO_SALIDANull ? (object)"<NULL>" : TURNO_SALIDA);
			dynStr.Append("@CBA@TURNO_SALIDA_DESPUES=");
			dynStr.Append(IsTURNO_SALIDA_DESPUESNull ? (object)"<NULL>" : TURNO_SALIDA_DESPUES);
			dynStr.Append("@CBA@TURNO_ID=");
			dynStr.Append(IsTURNO_IDNull ? (object)"<NULL>" : TURNO_ID);
			dynStr.Append("@CBA@DESCUENTO_LLEGADA_TARDIA_ID=");
			dynStr.Append(IsDESCUENTO_LLEGADA_TARDIA_IDNull ? (object)"<NULL>" : DESCUENTO_LLEGADA_TARDIA_ID);
			return dynStr.ToString();
		}
	} // End of MARCACIONESRow_Base class
} // End of namespace
