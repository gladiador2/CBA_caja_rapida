// <fileinfo name="LEGAJO_SUBENTS_INF_COMPLRow_Base.cs">
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
	/// The base class for <see cref="LEGAJO_SUBENTS_INF_COMPLRow"/> that 
	/// represents a record in the <c>LEGAJO_SUBENTS_INF_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LEGAJO_SUBENTS_INF_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LEGAJO_SUBENTS_INF_COMPLRow_Base
	{
		private decimal _id;
		private decimal _legajo_entrada_id;
		private string _legajo_entrada_nombre;
		private string _legajo_entrada_desc;
		private string _nombre;
		private string _descripcion;
		private string _estado;
		private decimal _tipo_detalle_personalizado_id;
		private bool _tipo_detalle_personalizado_idNull = true;
		private string _tipo_detalle_personali_nombre;
		private string _unico;

		/// <summary>
		/// Initializes a new instance of the <see cref="LEGAJO_SUBENTS_INF_COMPLRow_Base"/> class.
		/// </summary>
		public LEGAJO_SUBENTS_INF_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LEGAJO_SUBENTS_INF_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.LEGAJO_ENTRADA_ID != original.LEGAJO_ENTRADA_ID) return true;
			if (this.LEGAJO_ENTRADA_NOMBRE != original.LEGAJO_ENTRADA_NOMBRE) return true;
			if (this.LEGAJO_ENTRADA_DESC != original.LEGAJO_ENTRADA_DESC) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.IsTIPO_DETALLE_PERSONALIZADO_IDNull != original.IsTIPO_DETALLE_PERSONALIZADO_IDNull) return true;
			if (!this.IsTIPO_DETALLE_PERSONALIZADO_IDNull && !original.IsTIPO_DETALLE_PERSONALIZADO_IDNull)
				if (this.TIPO_DETALLE_PERSONALIZADO_ID != original.TIPO_DETALLE_PERSONALIZADO_ID) return true;
			if (this.TIPO_DETALLE_PERSONALI_NOMBRE != original.TIPO_DETALLE_PERSONALI_NOMBRE) return true;
			if (this.UNICO != original.UNICO) return true;
			
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
		/// Gets or sets the <c>LEGAJO_ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>LEGAJO_ENTRADA_ID</c> column value.</value>
		public decimal LEGAJO_ENTRADA_ID
		{
			get { return _legajo_entrada_id; }
			set { _legajo_entrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LEGAJO_ENTRADA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>LEGAJO_ENTRADA_NOMBRE</c> column value.</value>
		public string LEGAJO_ENTRADA_NOMBRE
		{
			get { return _legajo_entrada_nombre; }
			set { _legajo_entrada_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LEGAJO_ENTRADA_DESC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LEGAJO_ENTRADA_DESC</c> column value.</value>
		public string LEGAJO_ENTRADA_DESC
		{
			get { return _legajo_entrada_desc; }
			set { _legajo_entrada_desc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
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
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DETALLE_PERSONALIZADO_ID</c> column value.</value>
		public decimal TIPO_DETALLE_PERSONALIZADO_ID
		{
			get
			{
				if(IsTIPO_DETALLE_PERSONALIZADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_detalle_personalizado_id;
			}
			set
			{
				_tipo_detalle_personalizado_idNull = false;
				_tipo_detalle_personalizado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_DETALLE_PERSONALIZADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_DETALLE_PERSONALIZADO_IDNull
		{
			get { return _tipo_detalle_personalizado_idNull; }
			set { _tipo_detalle_personalizado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DETALLE_PERSONALI_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_DETALLE_PERSONALI_NOMBRE</c> column value.</value>
		public string TIPO_DETALLE_PERSONALI_NOMBRE
		{
			get { return _tipo_detalle_personali_nombre; }
			set { _tipo_detalle_personali_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>UNICO</c> column value.
		/// </summary>
		/// <value>The <c>UNICO</c> column value.</value>
		public string UNICO
		{
			get { return _unico; }
			set { _unico = value; }
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
			dynStr.Append("@CBA@LEGAJO_ENTRADA_ID=");
			dynStr.Append(LEGAJO_ENTRADA_ID);
			dynStr.Append("@CBA@LEGAJO_ENTRADA_NOMBRE=");
			dynStr.Append(LEGAJO_ENTRADA_NOMBRE);
			dynStr.Append("@CBA@LEGAJO_ENTRADA_DESC=");
			dynStr.Append(LEGAJO_ENTRADA_DESC);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@TIPO_DETALLE_PERSONALIZADO_ID=");
			dynStr.Append(IsTIPO_DETALLE_PERSONALIZADO_IDNull ? (object)"<NULL>" : TIPO_DETALLE_PERSONALIZADO_ID);
			dynStr.Append("@CBA@TIPO_DETALLE_PERSONALI_NOMBRE=");
			dynStr.Append(TIPO_DETALLE_PERSONALI_NOMBRE);
			dynStr.Append("@CBA@UNICO=");
			dynStr.Append(UNICO);
			return dynStr.ToString();
		}
	} // End of LEGAJO_SUBENTS_INF_COMPLRow_Base class
} // End of namespace
