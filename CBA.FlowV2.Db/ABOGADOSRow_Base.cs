// <fileinfo name="ABOGADOSRow_Base.cs">
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
	/// The base class for <see cref="ABOGADOSRow"/> that 
	/// represents a record in the <c>ABOGADOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ABOGADOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ABOGADOSRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private string _nombre;
		private string _apellido;
		private string _nombre_estudio;
		private string _ruc;
		private string _telefono1;
		private string _telefono2;
		private string _telefono3;
		private string _telefono4;
		private string _email1;
		private string _email2;
		private string _email3;
		private decimal _pais_id;
		private bool _pais_idNull = true;
		private decimal _departamento_id;
		private bool _departamento_idNull = true;
		private decimal _ciudad_id;
		private bool _ciudad_idNull = true;
		private decimal _barrio_id;
		private bool _barrio_idNull = true;
		private string _calle;
		private string _codigo_postal;
		private string _nombre_contacto;
		private string _telefono_contacto;
		private string _email_contacto;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="ABOGADOSRow_Base"/> class.
		/// </summary>
		public ABOGADOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ABOGADOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.APELLIDO != original.APELLIDO) return true;
			if (this.NOMBRE_ESTUDIO != original.NOMBRE_ESTUDIO) return true;
			if (this.RUC != original.RUC) return true;
			if (this.TELEFONO1 != original.TELEFONO1) return true;
			if (this.TELEFONO2 != original.TELEFONO2) return true;
			if (this.TELEFONO3 != original.TELEFONO3) return true;
			if (this.TELEFONO4 != original.TELEFONO4) return true;
			if (this.EMAIL1 != original.EMAIL1) return true;
			if (this.EMAIL2 != original.EMAIL2) return true;
			if (this.EMAIL3 != original.EMAIL3) return true;
			if (this.IsPAIS_IDNull != original.IsPAIS_IDNull) return true;
			if (!this.IsPAIS_IDNull && !original.IsPAIS_IDNull)
				if (this.PAIS_ID != original.PAIS_ID) return true;
			if (this.IsDEPARTAMENTO_IDNull != original.IsDEPARTAMENTO_IDNull) return true;
			if (!this.IsDEPARTAMENTO_IDNull && !original.IsDEPARTAMENTO_IDNull)
				if (this.DEPARTAMENTO_ID != original.DEPARTAMENTO_ID) return true;
			if (this.IsCIUDAD_IDNull != original.IsCIUDAD_IDNull) return true;
			if (!this.IsCIUDAD_IDNull && !original.IsCIUDAD_IDNull)
				if (this.CIUDAD_ID != original.CIUDAD_ID) return true;
			if (this.IsBARRIO_IDNull != original.IsBARRIO_IDNull) return true;
			if (!this.IsBARRIO_IDNull && !original.IsBARRIO_IDNull)
				if (this.BARRIO_ID != original.BARRIO_ID) return true;
			if (this.CALLE != original.CALLE) return true;
			if (this.CODIGO_POSTAL != original.CODIGO_POSTAL) return true;
			if (this.NOMBRE_CONTACTO != original.NOMBRE_CONTACTO) return true;
			if (this.TELEFONO_CONTACTO != original.TELEFONO_CONTACTO) return true;
			if (this.EMAIL_CONTACTO != original.EMAIL_CONTACTO) return true;
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
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
		/// Gets or sets the <c>APELLIDO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>APELLIDO</c> column value.</value>
		public string APELLIDO
		{
			get { return _apellido; }
			set { _apellido = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_ESTUDIO</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_ESTUDIO</c> column value.</value>
		public string NOMBRE_ESTUDIO
		{
			get { return _nombre_estudio; }
			set { _nombre_estudio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>RUC</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>RUC</c> column value.</value>
		public string RUC
		{
			get { return _ruc; }
			set { _ruc = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO1</c> column value.</value>
		public string TELEFONO1
		{
			get { return _telefono1; }
			set { _telefono1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO2</c> column value.</value>
		public string TELEFONO2
		{
			get { return _telefono2; }
			set { _telefono2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO3</c> column value.</value>
		public string TELEFONO3
		{
			get { return _telefono3; }
			set { _telefono3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO4</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO4</c> column value.</value>
		public string TELEFONO4
		{
			get { return _telefono4; }
			set { _telefono4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL1</c> column value.</value>
		public string EMAIL1
		{
			get { return _email1; }
			set { _email1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL2</c> column value.</value>
		public string EMAIL2
		{
			get { return _email2; }
			set { _email2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL3</c> column value.</value>
		public string EMAIL3
		{
			get { return _email3; }
			set { _email3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PAIS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PAIS_ID</c> column value.</value>
		public decimal PAIS_ID
		{
			get
			{
				if(IsPAIS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _pais_id;
			}
			set
			{
				_pais_idNull = false;
				_pais_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PAIS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPAIS_IDNull
		{
			get { return _pais_idNull; }
			set { _pais_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DEPARTAMENTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DEPARTAMENTO_ID</c> column value.</value>
		public decimal DEPARTAMENTO_ID
		{
			get
			{
				if(IsDEPARTAMENTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _departamento_id;
			}
			set
			{
				_departamento_idNull = false;
				_departamento_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DEPARTAMENTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDEPARTAMENTO_IDNull
		{
			get { return _departamento_idNull; }
			set { _departamento_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CIUDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CIUDAD_ID</c> column value.</value>
		public decimal CIUDAD_ID
		{
			get
			{
				if(IsCIUDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ciudad_id;
			}
			set
			{
				_ciudad_idNull = false;
				_ciudad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CIUDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCIUDAD_IDNull
		{
			get { return _ciudad_idNull; }
			set { _ciudad_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>BARRIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>BARRIO_ID</c> column value.</value>
		public decimal BARRIO_ID
		{
			get
			{
				if(IsBARRIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _barrio_id;
			}
			set
			{
				_barrio_idNull = false;
				_barrio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="BARRIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsBARRIO_IDNull
		{
			get { return _barrio_idNull; }
			set { _barrio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CALLE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CALLE</c> column value.</value>
		public string CALLE
		{
			get { return _calle; }
			set { _calle = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CODIGO_POSTAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO_POSTAL</c> column value.</value>
		public string CODIGO_POSTAL
		{
			get { return _codigo_postal; }
			set { _codigo_postal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_CONTACTO</c> column value.</value>
		public string NOMBRE_CONTACTO
		{
			get { return _nombre_contacto; }
			set { _nombre_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TELEFONO_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TELEFONO_CONTACTO</c> column value.</value>
		public string TELEFONO_CONTACTO
		{
			get { return _telefono_contacto; }
			set { _telefono_contacto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EMAIL_CONTACTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EMAIL_CONTACTO</c> column value.</value>
		public string EMAIL_CONTACTO
		{
			get { return _email_contacto; }
			set { _email_contacto = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@APELLIDO=");
			dynStr.Append(APELLIDO);
			dynStr.Append("@CBA@NOMBRE_ESTUDIO=");
			dynStr.Append(NOMBRE_ESTUDIO);
			dynStr.Append("@CBA@RUC=");
			dynStr.Append(RUC);
			dynStr.Append("@CBA@TELEFONO1=");
			dynStr.Append(TELEFONO1);
			dynStr.Append("@CBA@TELEFONO2=");
			dynStr.Append(TELEFONO2);
			dynStr.Append("@CBA@TELEFONO3=");
			dynStr.Append(TELEFONO3);
			dynStr.Append("@CBA@TELEFONO4=");
			dynStr.Append(TELEFONO4);
			dynStr.Append("@CBA@EMAIL1=");
			dynStr.Append(EMAIL1);
			dynStr.Append("@CBA@EMAIL2=");
			dynStr.Append(EMAIL2);
			dynStr.Append("@CBA@EMAIL3=");
			dynStr.Append(EMAIL3);
			dynStr.Append("@CBA@PAIS_ID=");
			dynStr.Append(IsPAIS_IDNull ? (object)"<NULL>" : PAIS_ID);
			dynStr.Append("@CBA@DEPARTAMENTO_ID=");
			dynStr.Append(IsDEPARTAMENTO_IDNull ? (object)"<NULL>" : DEPARTAMENTO_ID);
			dynStr.Append("@CBA@CIUDAD_ID=");
			dynStr.Append(IsCIUDAD_IDNull ? (object)"<NULL>" : CIUDAD_ID);
			dynStr.Append("@CBA@BARRIO_ID=");
			dynStr.Append(IsBARRIO_IDNull ? (object)"<NULL>" : BARRIO_ID);
			dynStr.Append("@CBA@CALLE=");
			dynStr.Append(CALLE);
			dynStr.Append("@CBA@CODIGO_POSTAL=");
			dynStr.Append(CODIGO_POSTAL);
			dynStr.Append("@CBA@NOMBRE_CONTACTO=");
			dynStr.Append(NOMBRE_CONTACTO);
			dynStr.Append("@CBA@TELEFONO_CONTACTO=");
			dynStr.Append(TELEFONO_CONTACTO);
			dynStr.Append("@CBA@EMAIL_CONTACTO=");
			dynStr.Append(EMAIL_CONTACTO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of ABOGADOSRow_Base class
} // End of namespace
