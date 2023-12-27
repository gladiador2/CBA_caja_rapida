// <fileinfo name="NOTIFICACIONESRow_Base.cs">
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
	/// The base class for <see cref="NOTIFICACIONESRow"/> that 
	/// represents a record in the <c>NOTIFICACIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="NOTIFICACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class NOTIFICACIONESRow_Base
	{
		private decimal _id;
		private string _accion_creacion;
		private string _accion_edicion;
		private decimal _flujo_id;
		private bool _flujo_idNull = true;
		private decimal _transicion_id;
		private bool _transicion_idNull = true;
		private string _tabla_id;
		private decimal _log_campo_id;
		private bool _log_campo_idNull = true;
		private string _condicion_valor;
		private string _condicion_sql;
		private string _estado;
		private string _plantilla_larga;
		private string _plantilla_corta;
		private string _plantilla_asunto;
		private string _descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="NOTIFICACIONESRow_Base"/> class.
		/// </summary>
		public NOTIFICACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(NOTIFICACIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ACCION_CREACION != original.ACCION_CREACION) return true;
			if (this.ACCION_EDICION != original.ACCION_EDICION) return true;
			if (this.IsFLUJO_IDNull != original.IsFLUJO_IDNull) return true;
			if (!this.IsFLUJO_IDNull && !original.IsFLUJO_IDNull)
				if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.IsTRANSICION_IDNull != original.IsTRANSICION_IDNull) return true;
			if (!this.IsTRANSICION_IDNull && !original.IsTRANSICION_IDNull)
				if (this.TRANSICION_ID != original.TRANSICION_ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.IsLOG_CAMPO_IDNull != original.IsLOG_CAMPO_IDNull) return true;
			if (!this.IsLOG_CAMPO_IDNull && !original.IsLOG_CAMPO_IDNull)
				if (this.LOG_CAMPO_ID != original.LOG_CAMPO_ID) return true;
			if (this.CONDICION_VALOR != original.CONDICION_VALOR) return true;
			if (this.CONDICION_SQL != original.CONDICION_SQL) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.PLANTILLA_LARGA != original.PLANTILLA_LARGA) return true;
			if (this.PLANTILLA_CORTA != original.PLANTILLA_CORTA) return true;
			if (this.PLANTILLA_ASUNTO != original.PLANTILLA_ASUNTO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			
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
		/// Gets or sets the <c>ACCION_CREACION</c> column value.
		/// </summary>
		/// <value>The <c>ACCION_CREACION</c> column value.</value>
		public string ACCION_CREACION
		{
			get { return _accion_creacion; }
			set { _accion_creacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ACCION_EDICION</c> column value.
		/// </summary>
		/// <value>The <c>ACCION_EDICION</c> column value.</value>
		public string ACCION_EDICION
		{
			get { return _accion_edicion; }
			set { _accion_edicion = value; }
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
		/// Gets or sets the <c>TRANSICION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRANSICION_ID</c> column value.</value>
		public decimal TRANSICION_ID
		{
			get
			{
				if(IsTRANSICION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _transicion_id;
			}
			set
			{
				_transicion_idNull = false;
				_transicion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRANSICION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRANSICION_IDNull
		{
			get { return _transicion_idNull; }
			set { _transicion_idNull = value; }
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
		/// Gets or sets the <c>LOG_CAMPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LOG_CAMPO_ID</c> column value.</value>
		public decimal LOG_CAMPO_ID
		{
			get
			{
				if(IsLOG_CAMPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _log_campo_id;
			}
			set
			{
				_log_campo_idNull = false;
				_log_campo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LOG_CAMPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLOG_CAMPO_IDNull
		{
			get { return _log_campo_idNull; }
			set { _log_campo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_VALOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_VALOR</c> column value.</value>
		public string CONDICION_VALOR
		{
			get { return _condicion_valor; }
			set { _condicion_valor = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONDICION_SQL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONDICION_SQL</c> column value.</value>
		public string CONDICION_SQL
		{
			get { return _condicion_sql; }
			set { _condicion_sql = value; }
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
		/// Gets or sets the <c>PLANTILLA_LARGA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANTILLA_LARGA</c> column value.</value>
		public string PLANTILLA_LARGA
		{
			get { return _plantilla_larga; }
			set { _plantilla_larga = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANTILLA_CORTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANTILLA_CORTA</c> column value.</value>
		public string PLANTILLA_CORTA
		{
			get { return _plantilla_corta; }
			set { _plantilla_corta = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANTILLA_ASUNTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANTILLA_ASUNTO</c> column value.</value>
		public string PLANTILLA_ASUNTO
		{
			get { return _plantilla_asunto; }
			set { _plantilla_asunto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
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
			dynStr.Append("@CBA@ACCION_CREACION=");
			dynStr.Append(ACCION_CREACION);
			dynStr.Append("@CBA@ACCION_EDICION=");
			dynStr.Append(ACCION_EDICION);
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(IsFLUJO_IDNull ? (object)"<NULL>" : FLUJO_ID);
			dynStr.Append("@CBA@TRANSICION_ID=");
			dynStr.Append(IsTRANSICION_IDNull ? (object)"<NULL>" : TRANSICION_ID);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@LOG_CAMPO_ID=");
			dynStr.Append(IsLOG_CAMPO_IDNull ? (object)"<NULL>" : LOG_CAMPO_ID);
			dynStr.Append("@CBA@CONDICION_VALOR=");
			dynStr.Append(CONDICION_VALOR);
			dynStr.Append("@CBA@CONDICION_SQL=");
			dynStr.Append(CONDICION_SQL);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@PLANTILLA_LARGA=");
			dynStr.Append(PLANTILLA_LARGA);
			dynStr.Append("@CBA@PLANTILLA_CORTA=");
			dynStr.Append(PLANTILLA_CORTA);
			dynStr.Append("@CBA@PLANTILLA_ASUNTO=");
			dynStr.Append(PLANTILLA_ASUNTO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of NOTIFICACIONESRow_Base class
} // End of namespace
