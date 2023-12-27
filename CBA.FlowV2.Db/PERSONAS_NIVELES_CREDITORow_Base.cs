// <fileinfo name="PERSONAS_NIVELES_CREDITORow_Base.cs">
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
	/// The base class for <see cref="PERSONAS_NIVELES_CREDITORow"/> that 
	/// represents a record in the <c>PERSONAS_NIVELES_CREDITO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PERSONAS_NIVELES_CREDITORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PERSONAS_NIVELES_CREDITORow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private decimal _limite_credito;
		private decimal _dias_gracia;
		private decimal _limite_inferior_credito;
		private decimal _rol_desbloqueo1;
		private bool _rol_desbloqueo1Null = true;
		private decimal _rol_desbloqueo2;
		private bool _rol_desbloqueo2Null = true;
		private decimal _rol_desbloqueo3;
		private bool _rol_desbloqueo3Null = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PERSONAS_NIVELES_CREDITORow_Base"/> class.
		/// </summary>
		public PERSONAS_NIVELES_CREDITORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PERSONAS_NIVELES_CREDITORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.LIMITE_CREDITO != original.LIMITE_CREDITO) return true;
			if (this.DIAS_GRACIA != original.DIAS_GRACIA) return true;
			if (this.LIMITE_INFERIOR_CREDITO != original.LIMITE_INFERIOR_CREDITO) return true;
			if (this.IsROL_DESBLOQUEO1Null != original.IsROL_DESBLOQUEO1Null) return true;
			if (!this.IsROL_DESBLOQUEO1Null && !original.IsROL_DESBLOQUEO1Null)
				if (this.ROL_DESBLOQUEO1 != original.ROL_DESBLOQUEO1) return true;
			if (this.IsROL_DESBLOQUEO2Null != original.IsROL_DESBLOQUEO2Null) return true;
			if (!this.IsROL_DESBLOQUEO2Null && !original.IsROL_DESBLOQUEO2Null)
				if (this.ROL_DESBLOQUEO2 != original.ROL_DESBLOQUEO2) return true;
			if (this.IsROL_DESBLOQUEO3Null != original.IsROL_DESBLOQUEO3Null) return true;
			if (!this.IsROL_DESBLOQUEO3Null && !original.IsROL_DESBLOQUEO3Null)
				if (this.ROL_DESBLOQUEO3 != original.ROL_DESBLOQUEO3) return true;
			
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
		/// Gets or sets the <c>LIMITE_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_CREDITO</c> column value.</value>
		public decimal LIMITE_CREDITO
		{
			get { return _limite_credito; }
			set { _limite_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_GRACIA</c> column value.
		/// </summary>
		/// <value>The <c>DIAS_GRACIA</c> column value.</value>
		public decimal DIAS_GRACIA
		{
			get { return _dias_gracia; }
			set { _dias_gracia = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_INFERIOR_CREDITO</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_INFERIOR_CREDITO</c> column value.</value>
		public decimal LIMITE_INFERIOR_CREDITO
		{
			get { return _limite_inferior_credito; }
			set { _limite_inferior_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_DESBLOQUEO1</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_DESBLOQUEO1</c> column value.</value>
		public decimal ROL_DESBLOQUEO1
		{
			get
			{
				if(IsROL_DESBLOQUEO1Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_desbloqueo1;
			}
			set
			{
				_rol_desbloqueo1Null = false;
				_rol_desbloqueo1 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_DESBLOQUEO1"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_DESBLOQUEO1Null
		{
			get { return _rol_desbloqueo1Null; }
			set { _rol_desbloqueo1Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_DESBLOQUEO2</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_DESBLOQUEO2</c> column value.</value>
		public decimal ROL_DESBLOQUEO2
		{
			get
			{
				if(IsROL_DESBLOQUEO2Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_desbloqueo2;
			}
			set
			{
				_rol_desbloqueo2Null = false;
				_rol_desbloqueo2 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_DESBLOQUEO2"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_DESBLOQUEO2Null
		{
			get { return _rol_desbloqueo2Null; }
			set { _rol_desbloqueo2Null = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ROL_DESBLOQUEO3</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ROL_DESBLOQUEO3</c> column value.</value>
		public decimal ROL_DESBLOQUEO3
		{
			get
			{
				if(IsROL_DESBLOQUEO3Null)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _rol_desbloqueo3;
			}
			set
			{
				_rol_desbloqueo3Null = false;
				_rol_desbloqueo3 = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ROL_DESBLOQUEO3"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsROL_DESBLOQUEO3Null
		{
			get { return _rol_desbloqueo3Null; }
			set { _rol_desbloqueo3Null = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@LIMITE_CREDITO=");
			dynStr.Append(LIMITE_CREDITO);
			dynStr.Append("@CBA@DIAS_GRACIA=");
			dynStr.Append(DIAS_GRACIA);
			dynStr.Append("@CBA@LIMITE_INFERIOR_CREDITO=");
			dynStr.Append(LIMITE_INFERIOR_CREDITO);
			dynStr.Append("@CBA@ROL_DESBLOQUEO1=");
			dynStr.Append(IsROL_DESBLOQUEO1Null ? (object)"<NULL>" : ROL_DESBLOQUEO1);
			dynStr.Append("@CBA@ROL_DESBLOQUEO2=");
			dynStr.Append(IsROL_DESBLOQUEO2Null ? (object)"<NULL>" : ROL_DESBLOQUEO2);
			dynStr.Append("@CBA@ROL_DESBLOQUEO3=");
			dynStr.Append(IsROL_DESBLOQUEO3Null ? (object)"<NULL>" : ROL_DESBLOQUEO3);
			return dynStr.ToString();
		}
	} // End of PERSONAS_NIVELES_CREDITORow_Base class
} // End of namespace
