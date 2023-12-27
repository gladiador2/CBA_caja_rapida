// <fileinfo name="TARIFARIOS_DATOS_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="TARIFARIOS_DATOS_INF_COMPRow"/> that 
	/// represents a record in the <c>TARIFARIOS_DATOS_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TARIFARIOS_DATOS_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TARIFARIOS_DATOS_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _tarifario_id;
		private string _tarifarios_nombre;
		private string _valor;
		private string _estado;
		private System.DateTime _fecha_modificacion;
		private decimal _usuario_modificacion_id;
		private string _usuario_modificacion_nombre;
		private string _fila_especial;
		private decimal _dato_relacionado_id;
		private bool _dato_relacionado_idNull = true;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private string _funcionario_codigo;
		private decimal _persona_id;
		private string _persona_nombre;
		private string _persona_codigo;
		private string _tipo_valor;

		/// <summary>
		/// Initializes a new instance of the <see cref="TARIFARIOS_DATOS_INF_COMPRow_Base"/> class.
		/// </summary>
		public TARIFARIOS_DATOS_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TARIFARIOS_DATOS_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TARIFARIO_ID != original.TARIFARIO_ID) return true;
			if (this.TARIFARIOS_NOMBRE != original.TARIFARIOS_NOMBRE) return true;
			if (this.VALOR != original.VALOR) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.FECHA_MODIFICACION != original.FECHA_MODIFICACION) return true;
			if (this.USUARIO_MODIFICACION_ID != original.USUARIO_MODIFICACION_ID) return true;
			if (this.USUARIO_MODIFICACION_NOMBRE != original.USUARIO_MODIFICACION_NOMBRE) return true;
			if (this.FILA_ESPECIAL != original.FILA_ESPECIAL) return true;
			if (this.IsDATO_RELACIONADO_IDNull != original.IsDATO_RELACIONADO_IDNull) return true;
			if (!this.IsDATO_RELACIONADO_IDNull && !original.IsDATO_RELACIONADO_IDNull)
				if (this.DATO_RELACIONADO_ID != original.DATO_RELACIONADO_ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_CODIGO != original.FUNCIONARIO_CODIGO) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			if (this.PERSONA_CODIGO != original.PERSONA_CODIGO) return true;
			if (this.TIPO_VALOR != original.TIPO_VALOR) return true;
			
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
		/// Gets or sets the <c>TARIFARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TARIFARIO_ID</c> column value.</value>
		public decimal TARIFARIO_ID
		{
			get { return _tarifario_id; }
			set { _tarifario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARIFARIOS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TARIFARIOS_NOMBRE</c> column value.</value>
		public string TARIFARIOS_NOMBRE
		{
			get { return _tarifarios_nombre; }
			set { _tarifarios_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR</c> column value.</value>
		public string VALOR
		{
			get { return _valor; }
			set { _valor = value; }
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
		/// Gets or sets the <c>FECHA_MODIFICACION</c> column value.
		/// </summary>
		/// <value>The <c>FECHA_MODIFICACION</c> column value.</value>
		public System.DateTime FECHA_MODIFICACION
		{
			get { return _fecha_modificacion; }
			set { _fecha_modificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_MODIFICACION_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICACION_ID</c> column value.</value>
		public decimal USUARIO_MODIFICACION_ID
		{
			get { return _usuario_modificacion_id; }
			set { _usuario_modificacion_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_MODIFICACION_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_MODIFICACION_NOMBRE</c> column value.</value>
		public string USUARIO_MODIFICACION_NOMBRE
		{
			get { return _usuario_modificacion_nombre; }
			set { _usuario_modificacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FILA_ESPECIAL</c> column value.
		/// </summary>
		/// <value>The <c>FILA_ESPECIAL</c> column value.</value>
		public string FILA_ESPECIAL
		{
			get { return _fila_especial; }
			set { _fila_especial = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DATO_RELACIONADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DATO_RELACIONADO_ID</c> column value.</value>
		public decimal DATO_RELACIONADO_ID
		{
			get
			{
				if(IsDATO_RELACIONADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dato_relacionado_id;
			}
			set
			{
				_dato_relacionado_idNull = false;
				_dato_relacionado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DATO_RELACIONADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDATO_RELACIONADO_IDNull
		{
			get { return _dato_relacionado_idNull; }
			set { _dato_relacionado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_CODIGO</c> column value.</value>
		public string FUNCIONARIO_CODIGO
		{
			get { return _funcionario_codigo; }
			set { _funcionario_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_CODIGO</c> column value.</value>
		public string PERSONA_CODIGO
		{
			get { return _persona_codigo; }
			set { _persona_codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_VALOR</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_VALOR</c> column value.</value>
		public string TIPO_VALOR
		{
			get { return _tipo_valor; }
			set { _tipo_valor = value; }
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
			dynStr.Append("@CBA@TARIFARIO_ID=");
			dynStr.Append(TARIFARIO_ID);
			dynStr.Append("@CBA@TARIFARIOS_NOMBRE=");
			dynStr.Append(TARIFARIOS_NOMBRE);
			dynStr.Append("@CBA@VALOR=");
			dynStr.Append(VALOR);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@FECHA_MODIFICACION=");
			dynStr.Append(FECHA_MODIFICACION);
			dynStr.Append("@CBA@USUARIO_MODIFICACION_ID=");
			dynStr.Append(USUARIO_MODIFICACION_ID);
			dynStr.Append("@CBA@USUARIO_MODIFICACION_NOMBRE=");
			dynStr.Append(USUARIO_MODIFICACION_NOMBRE);
			dynStr.Append("@CBA@FILA_ESPECIAL=");
			dynStr.Append(FILA_ESPECIAL);
			dynStr.Append("@CBA@DATO_RELACIONADO_ID=");
			dynStr.Append(IsDATO_RELACIONADO_IDNull ? (object)"<NULL>" : DATO_RELACIONADO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_CODIGO=");
			dynStr.Append(FUNCIONARIO_CODIGO);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			dynStr.Append("@CBA@PERSONA_CODIGO=");
			dynStr.Append(PERSONA_CODIGO);
			dynStr.Append("@CBA@TIPO_VALOR=");
			dynStr.Append(TIPO_VALOR);
			return dynStr.ToString();
		}
	} // End of TARIFARIOS_DATOS_INF_COMPRow_Base class
} // End of namespace
