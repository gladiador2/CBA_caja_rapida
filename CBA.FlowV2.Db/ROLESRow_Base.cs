// <fileinfo name="ROLESRow_Base.cs">
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
	/// The base class for <see cref="ROLESRow"/> that 
	/// represents a record in the <c>ROLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ROLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ROLESRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private bool _entidad_idNull = true;
		private string _descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="ROLESRow_Base"/> class.
		/// </summary>
		public ROLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ROLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsENTIDAD_IDNull != original.IsENTIDAD_IDNull) return true;
			if (!this.IsENTIDAD_IDNull && !original.IsENTIDAD_IDNull)
				if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
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
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get
			{
				if(IsENTIDAD_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _entidad_id;
			}
			set
			{
				_entidad_idNull = false;
				_entidad_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ENTIDAD_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsENTIDAD_IDNull
		{
			get { return _entidad_idNull; }
			set { _entidad_idNull = value; }
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
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(IsENTIDAD_IDNull ? (object)"<NULL>" : ENTIDAD_ID);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of ROLESRow_Base class
} // End of namespace
