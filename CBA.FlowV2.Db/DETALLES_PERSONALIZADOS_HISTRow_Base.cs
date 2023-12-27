// <fileinfo name="DETALLES_PERSONALIZADOS_HISTRow_Base.cs">
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
	/// The base class for <see cref="DETALLES_PERSONALIZADOS_HISTRow"/> that 
	/// represents a record in the <c>DETALLES_PERSONALIZADOS_HIST</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="DETALLES_PERSONALIZADOS_HISTRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class DETALLES_PERSONALIZADOS_HISTRow_Base
	{
		private decimal _id;
		private decimal _tipo_detalle_personalizado_id;
		private decimal _usuario_creacion_id;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_copiado_id;
		private System.DateTime _fecha_copiado;
		private string _tabla_id;
		private string _columna;
		private string _registro_id;
		private decimal _caso_id;

		/// <summary>
		/// Initializes a new instance of the <see cref="DETALLES_PERSONALIZADOS_HISTRow_Base"/> class.
		/// </summary>
		public DETALLES_PERSONALIZADOS_HISTRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(DETALLES_PERSONALIZADOS_HISTRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TIPO_DETALLE_PERSONALIZADO_ID != original.TIPO_DETALLE_PERSONALIZADO_ID) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_COPIADO_ID != original.USUARIO_COPIADO_ID) return true;
			if (this.FECHA_COPIADO != original.FECHA_COPIADO) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.COLUMNA != original.COLUMNA) return true;
			if (this.REGISTRO_ID != original.REGISTRO_ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			
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
		/// Gets or sets the <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</value>
		public decimal TIPO_DETALLE_PERSONALIZADO_ID
		{
			get { return _tipo_detalle_personalizado_id; }
			set { _tipo_detalle_personalizado_id = value; }
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
		/// Gets or sets the <c>USUARIO_COPIADO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_COPIADO_ID</c> column value.</value>
		public decimal USUARIO_COPIADO_ID
		{
			get { return _usuario_copiado_id; }
			set { _usuario_copiado_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_COPIADO</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_COPIADO</c> column value.</value>
		public System.DateTime FECHA_COPIADO
		{
			get { return _fecha_copiado; }
			set { _fecha_copiado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COLUMNA</c> column value.
		/// </summary>
		/// <value>The <c>COLUMNA</c> column value.</value>
		public string COLUMNA
		{
			get { return _columna; }
			set { _columna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>REGISTRO_ID</c> column value.
		/// </summary>
		/// <value>The <c>REGISTRO_ID</c> column value.</value>
		public string REGISTRO_ID
		{
			get { return _registro_id; }
			set { _registro_id = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@TIPO_DETALLE_PERSONALIZADO_ID=");
			dynStr.Append(TIPO_DETALLE_PERSONALIZADO_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_COPIADO_ID=");
			dynStr.Append(USUARIO_COPIADO_ID);
			dynStr.Append("@CBA@FECHA_COPIADO=");
			dynStr.Append(FECHA_COPIADO);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@COLUMNA=");
			dynStr.Append(COLUMNA);
			dynStr.Append("@CBA@REGISTRO_ID=");
			dynStr.Append(REGISTRO_ID);
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			return dynStr.ToString();
		}
	} // End of DETALLES_PERSONALIZADOS_HISTRow_Base class
} // End of namespace
