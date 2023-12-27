// <fileinfo name="TRANSICIONESRow_Base.cs">
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
	/// The base class for <see cref="TRANSICIONESRow"/> that 
	/// represents a record in the <c>TRANSICIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRANSICIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRANSICIONESRow_Base
	{
		private decimal _id;
		private decimal _flujo_id;
		private string _estado_origen_id;
		private string _estado_destino_id;
		private decimal _rol_id;
		private string _sql;
		private decimal _orden;
		private bool _ordenNull = true;
		private decimal _entidad_id;
		private string _estado;
		private string _comentario_obligatorio;
		private string _asignacion_caso_obligatorio;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRANSICIONESRow_Base"/> class.
		/// </summary>
		public TRANSICIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRANSICIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FLUJO_ID != original.FLUJO_ID) return true;
			if (this.ESTADO_ORIGEN_ID != original.ESTADO_ORIGEN_ID) return true;
			if (this.ESTADO_DESTINO_ID != original.ESTADO_DESTINO_ID) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			if (this.SQL != original.SQL) return true;
			if (this.IsORDENNull != original.IsORDENNull) return true;
			if (!this.IsORDENNull && !original.IsORDENNull)
				if (this.ORDEN != original.ORDEN) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.COMENTARIO_OBLIGATORIO != original.COMENTARIO_OBLIGATORIO) return true;
			if (this.ASIGNACION_CASO_OBLIGATORIO != original.ASIGNACION_CASO_OBLIGATORIO) return true;
			
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
		/// Gets or sets the <c>FLUJO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FLUJO_ID</c> column value.</value>
		public decimal FLUJO_ID
		{
			get { return _flujo_id; }
			set { _flujo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_ORIGEN_ID</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_ORIGEN_ID</c> column value.</value>
		public string ESTADO_ORIGEN_ID
		{
			get { return _estado_origen_id; }
			set { _estado_origen_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO_DESTINO_ID</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO_DESTINO_ID</c> column value.</value>
		public string ESTADO_DESTINO_ID
		{
			get { return _estado_destino_id; }
			set { _estado_destino_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_ID</c> column value.
		/// </summary>
		/// <value>The <c>ROL_ID</c> column value.</value>
		public decimal ROL_ID
		{
			get { return _rol_id; }
			set { _rol_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SQL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SQL</c> column value.</value>
		public string SQL
		{
			get { return _sql; }
			set { _sql = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get
			{
				if(IsORDENNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _orden;
			}
			set
			{
				_ordenNull = false;
				_orden = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ORDEN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsORDENNull
		{
			get { return _ordenNull; }
			set { _ordenNull = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO_OBLIGATORIO</c> column value.
		/// </summary>
		/// <value>The <c>COMENTARIO_OBLIGATORIO</c> column value.</value>
		public string COMENTARIO_OBLIGATORIO
		{
			get { return _comentario_obligatorio; }
			set { _comentario_obligatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ASIGNACION_CASO_OBLIGATORIO</c> column value.
		/// </summary>
		/// <value>The <c>ASIGNACION_CASO_OBLIGATORIO</c> column value.</value>
		public string ASIGNACION_CASO_OBLIGATORIO
		{
			get { return _asignacion_caso_obligatorio; }
			set { _asignacion_caso_obligatorio = value; }
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
			dynStr.Append("@CBA@FLUJO_ID=");
			dynStr.Append(FLUJO_ID);
			dynStr.Append("@CBA@ESTADO_ORIGEN_ID=");
			dynStr.Append(ESTADO_ORIGEN_ID);
			dynStr.Append("@CBA@ESTADO_DESTINO_ID=");
			dynStr.Append(ESTADO_DESTINO_ID);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			dynStr.Append("@CBA@SQL=");
			dynStr.Append(SQL);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(IsORDENNull ? (object)"<NULL>" : ORDEN);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@COMENTARIO_OBLIGATORIO=");
			dynStr.Append(COMENTARIO_OBLIGATORIO);
			dynStr.Append("@CBA@ASIGNACION_CASO_OBLIGATORIO=");
			dynStr.Append(ASIGNACION_CASO_OBLIGATORIO);
			return dynStr.ToString();
		}
	} // End of TRANSICIONESRow_Base class
} // End of namespace
