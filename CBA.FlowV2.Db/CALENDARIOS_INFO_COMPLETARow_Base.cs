// <fileinfo name="CALENDARIOS_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CALENDARIOS_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CALENDARIOS_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CALENDARIOS_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CALENDARIOS_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;
		private string _sucursal_nombre;
		private string _tipo_evento_calendario_id;
		private string _laborable;
		private System.DateTime _fecha;
		private string _titulo;
		private string _observacion;
		private string _estado;
		private string _es_ciclico;
		private System.DateTime _tolerancia_minutos_extras;
		private bool _tolerancia_minutos_extrasNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CALENDARIOS_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CALENDARIOS_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CALENDARIOS_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.SUCURSAL_NOMBRE != original.SUCURSAL_NOMBRE) return true;
			if (this.TIPO_EVENTO_CALENDARIO_ID != original.TIPO_EVENTO_CALENDARIO_ID) return true;
			if (this.LABORABLE != original.LABORABLE) return true;
			if (this.FECHA != original.FECHA) return true;
			if (this.TITULO != original.TITULO) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.ES_CICLICO != original.ES_CICLICO) return true;
			if (this.IsTOLERANCIA_MINUTOS_EXTRASNull != original.IsTOLERANCIA_MINUTOS_EXTRASNull) return true;
			if (!this.IsTOLERANCIA_MINUTOS_EXTRASNull && !original.IsTOLERANCIA_MINUTOS_EXTRASNull)
				if (this.TOLERANCIA_MINUTOS_EXTRAS != original.TOLERANCIA_MINUTOS_EXTRAS) return true;
			
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
		/// Gets or sets the <c>SUCURSAL_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_NOMBRE</c> column value.</value>
		public string SUCURSAL_NOMBRE
		{
			get { return _sucursal_nombre; }
			set { _sucursal_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_EVENTO_CALENDARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_EVENTO_CALENDARIO_ID</c> column value.</value>
		public string TIPO_EVENTO_CALENDARIO_ID
		{
			get { return _tipo_evento_calendario_id; }
			set { _tipo_evento_calendario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LABORABLE</c> column value.
		/// </summary>
		/// <value>The <c>LABORABLE</c> column value.</value>
		public string LABORABLE
		{
			get { return _laborable; }
			set { _laborable = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_CICLICO</c> column value.
		/// </summary>
		/// <value>The <c>ES_CICLICO</c> column value.</value>
		public string ES_CICLICO
		{
			get { return _es_ciclico; }
			set { _es_ciclico = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TOLERANCIA_MINUTOS_EXTRAS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TOLERANCIA_MINUTOS_EXTRAS</c> column value.</value>
		public System.DateTime TOLERANCIA_MINUTOS_EXTRAS
		{
			get
			{
				if(IsTOLERANCIA_MINUTOS_EXTRASNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tolerancia_minutos_extras;
			}
			set
			{
				_tolerancia_minutos_extrasNull = false;
				_tolerancia_minutos_extras = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TOLERANCIA_MINUTOS_EXTRAS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTOLERANCIA_MINUTOS_EXTRASNull
		{
			get { return _tolerancia_minutos_extrasNull; }
			set { _tolerancia_minutos_extrasNull = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			dynStr.Append("@CBA@SUCURSAL_NOMBRE=");
			dynStr.Append(SUCURSAL_NOMBRE);
			dynStr.Append("@CBA@TIPO_EVENTO_CALENDARIO_ID=");
			dynStr.Append(TIPO_EVENTO_CALENDARIO_ID);
			dynStr.Append("@CBA@LABORABLE=");
			dynStr.Append(LABORABLE);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(FECHA);
			dynStr.Append("@CBA@TITULO=");
			dynStr.Append(TITULO);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@ES_CICLICO=");
			dynStr.Append(ES_CICLICO);
			dynStr.Append("@CBA@TOLERANCIA_MINUTOS_EXTRAS=");
			dynStr.Append(IsTOLERANCIA_MINUTOS_EXTRASNull ? (object)"<NULL>" : TOLERANCIA_MINUTOS_EXTRAS);
			return dynStr.ToString();
		}
	} // End of CALENDARIOS_INFO_COMPLETARow_Base class
} // End of namespace
