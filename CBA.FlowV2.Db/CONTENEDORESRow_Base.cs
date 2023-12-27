// <fileinfo name="CONTENEDORESRow_Base.cs">
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
	/// The base class for <see cref="CONTENEDORESRow"/> that 
	/// represents a record in the <c>CONTENEDORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTENEDORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORESRow_Base
	{
		private decimal _id;
		private string _numero;
		private decimal _linea_id;
		private decimal _agencia_id;
		private decimal _tipo_id;
		private decimal _tara;
		private decimal _capacidad;
		private decimal _peso_maximo;
		private string _estado;
		private string _en_predio;
		private System.DateTime _fecha_creacion;
		private decimal _usuario_creador_id;
		private string _clase;
		private string _bloqueado;
		private System.DateTime _habilitado_hasta;
		private bool _habilitado_hastaNull = true;
		private decimal _puerto_devolucion_id;
		private bool _puerto_devolucion_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORESRow_Base"/> class.
		/// </summary>
		public CONTENEDORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTENEDORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NUMERO != original.NUMERO) return true;
			if (this.LINEA_ID != original.LINEA_ID) return true;
			if (this.AGENCIA_ID != original.AGENCIA_ID) return true;
			if (this.TIPO_ID != original.TIPO_ID) return true;
			if (this.TARA != original.TARA) return true;
			if (this.CAPACIDAD != original.CAPACIDAD) return true;
			if (this.PESO_MAXIMO != original.PESO_MAXIMO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.EN_PREDIO != original.EN_PREDIO) return true;
			if (this.FECHA_CREACION != original.FECHA_CREACION) return true;
			if (this.USUARIO_CREADOR_ID != original.USUARIO_CREADOR_ID) return true;
			if (this.CLASE != original.CLASE) return true;
			if (this.BLOQUEADO != original.BLOQUEADO) return true;
			if (this.IsHABILITADO_HASTANull != original.IsHABILITADO_HASTANull) return true;
			if (!this.IsHABILITADO_HASTANull && !original.IsHABILITADO_HASTANull)
				if (this.HABILITADO_HASTA != original.HABILITADO_HASTA) return true;
			if (this.IsPUERTO_DEVOLUCION_IDNull != original.IsPUERTO_DEVOLUCION_IDNull) return true;
			if (!this.IsPUERTO_DEVOLUCION_IDNull && !original.IsPUERTO_DEVOLUCION_IDNull)
				if (this.PUERTO_DEVOLUCION_ID != original.PUERTO_DEVOLUCION_ID) return true;
			
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
		/// Gets or sets the <c>NUMERO</c> column value.
		/// </summary>
		/// <value>The <c>NUMERO</c> column value.</value>
		public string NUMERO
		{
			get { return _numero; }
			set { _numero = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LINEA_ID</c> column value.
		/// </summary>
		/// <value>The <c>LINEA_ID</c> column value.</value>
		public decimal LINEA_ID
		{
			get { return _linea_id; }
			set { _linea_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>AGENCIA_ID</c> column value.
		/// </summary>
		/// <value>The <c>AGENCIA_ID</c> column value.</value>
		public decimal AGENCIA_ID
		{
			get { return _agencia_id; }
			set { _agencia_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_ID</c> column value.</value>
		public decimal TIPO_ID
		{
			get { return _tipo_id; }
			set { _tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TARA</c> column value.
		/// </summary>
		/// <value>The <c>TARA</c> column value.</value>
		public decimal TARA
		{
			get { return _tara; }
			set { _tara = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CAPACIDAD</c> column value.
		/// </summary>
		/// <value>The <c>CAPACIDAD</c> column value.</value>
		public decimal CAPACIDAD
		{
			get { return _capacidad; }
			set { _capacidad = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PESO_MAXIMO</c> column value.
		/// </summary>
		/// <value>The <c>PESO_MAXIMO</c> column value.</value>
		public decimal PESO_MAXIMO
		{
			get { return _peso_maximo; }
			set { _peso_maximo = value; }
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
		/// Gets or sets the <c>EN_PREDIO</c> column value.
		/// </summary>
		/// <value>The <c>EN_PREDIO</c> column value.</value>
		public string EN_PREDIO
		{
			get { return _en_predio; }
			set { _en_predio = value; }
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
		/// Gets or sets the <c>USUARIO_CREADOR_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_CREADOR_ID</c> column value.</value>
		public decimal USUARIO_CREADOR_ID
		{
			get { return _usuario_creador_id; }
			set { _usuario_creador_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CLASE</c> column value.
		/// </summary>
		/// <value>The <c>CLASE</c> column value.</value>
		public string CLASE
		{
			get { return _clase; }
			set { _clase = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BLOQUEADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BLOQUEADO</c> column value.</value>
		public string BLOQUEADO
		{
			get { return _bloqueado; }
			set { _bloqueado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HABILITADO_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>HABILITADO_HASTA</c> column value.</value>
		public System.DateTime HABILITADO_HASTA
		{
			get
			{
				if(IsHABILITADO_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _habilitado_hasta;
			}
			set
			{
				_habilitado_hastaNull = false;
				_habilitado_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="HABILITADO_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsHABILITADO_HASTANull
		{
			get { return _habilitado_hastaNull; }
			set { _habilitado_hastaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PUERTO_DEVOLUCION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PUERTO_DEVOLUCION_ID</c> column value.</value>
		public decimal PUERTO_DEVOLUCION_ID
		{
			get
			{
				if(IsPUERTO_DEVOLUCION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _puerto_devolucion_id;
			}
			set
			{
				_puerto_devolucion_idNull = false;
				_puerto_devolucion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PUERTO_DEVOLUCION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPUERTO_DEVOLUCION_IDNull
		{
			get { return _puerto_devolucion_idNull; }
			set { _puerto_devolucion_idNull = value; }
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
			dynStr.Append("@CBA@NUMERO=");
			dynStr.Append(NUMERO);
			dynStr.Append("@CBA@LINEA_ID=");
			dynStr.Append(LINEA_ID);
			dynStr.Append("@CBA@AGENCIA_ID=");
			dynStr.Append(AGENCIA_ID);
			dynStr.Append("@CBA@TIPO_ID=");
			dynStr.Append(TIPO_ID);
			dynStr.Append("@CBA@TARA=");
			dynStr.Append(TARA);
			dynStr.Append("@CBA@CAPACIDAD=");
			dynStr.Append(CAPACIDAD);
			dynStr.Append("@CBA@PESO_MAXIMO=");
			dynStr.Append(PESO_MAXIMO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@EN_PREDIO=");
			dynStr.Append(EN_PREDIO);
			dynStr.Append("@CBA@FECHA_CREACION=");
			dynStr.Append(FECHA_CREACION);
			dynStr.Append("@CBA@USUARIO_CREADOR_ID=");
			dynStr.Append(USUARIO_CREADOR_ID);
			dynStr.Append("@CBA@CLASE=");
			dynStr.Append(CLASE);
			dynStr.Append("@CBA@BLOQUEADO=");
			dynStr.Append(BLOQUEADO);
			dynStr.Append("@CBA@HABILITADO_HASTA=");
			dynStr.Append(IsHABILITADO_HASTANull ? (object)"<NULL>" : HABILITADO_HASTA);
			dynStr.Append("@CBA@PUERTO_DEVOLUCION_ID=");
			dynStr.Append(IsPUERTO_DEVOLUCION_IDNull ? (object)"<NULL>" : PUERTO_DEVOLUCION_ID);
			return dynStr.ToString();
		}
	} // End of CONTENEDORESRow_Base class
} // End of namespace
