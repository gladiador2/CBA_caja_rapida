// <fileinfo name="LEGAJO_FUNCIONARIOS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="LEGAJO_FUNCIONARIOS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>LEGAJO_FUNCIONARIOS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="LEGAJO_FUNCIONARIOS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class LEGAJO_FUNCIONARIOS_INFO_COMPLRow_Base
	{
		private decimal _id;
		private decimal _funcionario_id;
		private string _funcionario_nombre;
		private decimal _funcionario_entidad_id;
		private string _funcionario_entidad_nombre;
		private decimal _tipo_entrada_id;
		private string _tipo_entrada_nombre;
		private string _observacion;
		private string _entrada_automatica;
		private System.DateTime _fecha_inicio;
		private bool _fecha_inicioNull = true;
		private System.DateTime _fecha_fin;
		private bool _fecha_finNull = true;
		private decimal _usuario_creacion_id;
		private string _usuario_creacion_nombre;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_anulacion_id;
		private bool _usuario_anulacion_idNull = true;
		private string _usuario_anulacion_nombre;
		private System.DateTime _fecha_anulacion;
		private bool _fecha_anulacionNull = true;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="LEGAJO_FUNCIONARIOS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public LEGAJO_FUNCIONARIOS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(LEGAJO_FUNCIONARIOS_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.FUNCIONARIO_ENTIDAD_ID != original.FUNCIONARIO_ENTIDAD_ID) return true;
			if (this.FUNCIONARIO_ENTIDAD_NOMBRE != original.FUNCIONARIO_ENTIDAD_NOMBRE) return true;
			if (this.TIPO_ENTRADA_ID != original.TIPO_ENTRADA_ID) return true;
			if (this.TIPO_ENTRADA_NOMBRE != original.TIPO_ENTRADA_NOMBRE) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			if (this.ENTRADA_AUTOMATICA != original.ENTRADA_AUTOMATICA) return true;
			if (this.IsFECHA_INICIONull != original.IsFECHA_INICIONull) return true;
			if (!this.IsFECHA_INICIONull && !original.IsFECHA_INICIONull)
				if (this.FECHA_INICIO != original.FECHA_INICIO) return true;
			if (this.IsFECHA_FINNull != original.IsFECHA_FINNull) return true;
			if (!this.IsFECHA_FINNull && !original.IsFECHA_FINNull)
				if (this.FECHA_FIN != original.FECHA_FIN) return true;
			if (this.USUARIO_CREACION_ID != original.USUARIO_CREACION_ID) return true;
			if (this.USUARIO_CREACION_NOMBRE != original.USUARIO_CREACION_NOMBRE) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.IsUSUARIO_ANULACION_IDNull != original.IsUSUARIO_ANULACION_IDNull) return true;
			if (!this.IsUSUARIO_ANULACION_IDNull && !original.IsUSUARIO_ANULACION_IDNull)
				if (this.USUARIO_ANULACION_ID != original.USUARIO_ANULACION_ID) return true;
			if (this.USUARIO_ANULACION_NOMBRE != original.USUARIO_ANULACION_NOMBRE) return true;
			if (this.IsFECHA_ANULACIONNull != original.IsFECHA_ANULACIONNull) return true;
			if (!this.IsFECHA_ANULACIONNull && !original.IsFECHA_ANULACIONNull)
				if (this.FECHA_ANULACION != original.FECHA_ANULACION) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>FUNCIONARIO_ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ENTIDAD_ID</c> column value.</value>
		public decimal FUNCIONARIO_ENTIDAD_ID
		{
			get { return _funcionario_entidad_id; }
			set { _funcionario_entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ENTIDAD_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ENTIDAD_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_ENTIDAD_NOMBRE
		{
			get { return _funcionario_entidad_nombre; }
			set { _funcionario_entidad_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ENTRADA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ENTRADA_ID</c> column value.</value>
		public decimal TIPO_ENTRADA_ID
		{
			get { return _tipo_entrada_id; }
			set { _tipo_entrada_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ENTRADA_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ENTRADA_NOMBRE</c> column value.</value>
		public string TIPO_ENTRADA_NOMBRE
		{
			get { return _tipo_entrada_nombre; }
			set { _tipo_entrada_nombre = value; }
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
		/// Gets or sets the <c>ENTRADA_AUTOMATICA</c> column value.
		/// </summary>
		/// <value>The <c>ENTRADA_AUTOMATICA</c> column value.</value>
		public string ENTRADA_AUTOMATICA
		{
			get { return _entrada_automatica; }
			set { _entrada_automatica = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_INICIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_INICIO</c> column value.</value>
		public System.DateTime FECHA_INICIO
		{
			get
			{
				if(IsFECHA_INICIONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_inicio;
			}
			set
			{
				_fecha_inicioNull = false;
				_fecha_inicio = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_INICIO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_INICIONull
		{
			get { return _fecha_inicioNull; }
			set { _fecha_inicioNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_FIN</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_FIN</c> column value.</value>
		public System.DateTime FECHA_FIN
		{
			get
			{
				if(IsFECHA_FINNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_fin;
			}
			set
			{
				_fecha_finNull = false;
				_fecha_fin = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_FIN"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_FINNull
		{
			get { return _fecha_finNull; }
			set { _fecha_finNull = value; }
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
		/// Gets or sets the <c>USUARIO_CREACION_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREACION_NOMBRE</c> column value.</value>
		public string USUARIO_CREACION_NOMBRE
		{
			get { return _usuario_creacion_nombre; }
			set { _usuario_creacion_nombre = value; }
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
		/// Gets or sets the <c>USUARIO_ANULACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ANULACION_ID</c> column value.</value>
		public decimal USUARIO_ANULACION_ID
		{
			get
			{
				if(IsUSUARIO_ANULACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _usuario_anulacion_id;
			}
			set
			{
				_usuario_anulacion_idNull = false;
				_usuario_anulacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USUARIO_ANULACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSUARIO_ANULACION_IDNull
		{
			get { return _usuario_anulacion_idNull; }
			set { _usuario_anulacion_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ANULACION_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USUARIO_ANULACION_NOMBRE</c> column value.</value>
		public string USUARIO_ANULACION_NOMBRE
		{
			get { return _usuario_anulacion_nombre; }
			set { _usuario_anulacion_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA_ANULACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_ANULACION</c> column value.</value>
		public System.DateTime FECHA_ANULACION
		{
			get
			{
				if(IsFECHA_ANULACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_anulacion;
			}
			set
			{
				_fecha_anulacionNull = false;
				_fecha_anulacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_ANULACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_ANULACIONNull
		{
			get { return _fecha_anulacionNull; }
			set { _fecha_anulacionNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@FUNCIONARIO_ENTIDAD_ID=");
			dynStr.Append(FUNCIONARIO_ENTIDAD_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ENTIDAD_NOMBRE=");
			dynStr.Append(FUNCIONARIO_ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@TIPO_ENTRADA_ID=");
			dynStr.Append(TIPO_ENTRADA_ID);
			dynStr.Append("@CBA@TIPO_ENTRADA_NOMBRE=");
			dynStr.Append(TIPO_ENTRADA_NOMBRE);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			dynStr.Append("@CBA@ENTRADA_AUTOMATICA=");
			dynStr.Append(ENTRADA_AUTOMATICA);
			dynStr.Append("@CBA@FECHA_INICIO=");
			dynStr.Append(IsFECHA_INICIONull ? (object)"<NULL>" : FECHA_INICIO);
			dynStr.Append("@CBA@FECHA_FIN=");
			dynStr.Append(IsFECHA_FINNull ? (object)"<NULL>" : FECHA_FIN);
			dynStr.Append("@CBA@USUARIO_CREACION_ID=");
			dynStr.Append(USUARIO_CREACION_ID);
			dynStr.Append("@CBA@USUARIO_CREACION_NOMBRE=");
			dynStr.Append(USUARIO_CREACION_NOMBRE);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_ANULACION_ID=");
			dynStr.Append(IsUSUARIO_ANULACION_IDNull ? (object)"<NULL>" : USUARIO_ANULACION_ID);
			dynStr.Append("@CBA@USUARIO_ANULACION_NOMBRE=");
			dynStr.Append(USUARIO_ANULACION_NOMBRE);
			dynStr.Append("@CBA@FECHA_ANULACION=");
			dynStr.Append(IsFECHA_ANULACIONNull ? (object)"<NULL>" : FECHA_ANULACION);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of LEGAJO_FUNCIONARIOS_INFO_COMPLRow_Base class
} // End of namespace
