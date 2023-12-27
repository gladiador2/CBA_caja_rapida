// <fileinfo name="USUARIOS_ROLESRow_Base.cs">
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
	/// The base class for <see cref="USUARIOS_ROLESRow"/> that 
	/// represents a record in the <c>USUARIOS_ROLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USUARIOS_ROLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOS_ROLESRow_Base
	{
		private decimal _usuario_id;
		private decimal _rol_id;
		private decimal _perfil_id;
		private bool _perfil_idNull = true;
		private decimal _id;
		private System.DateTime _fecha_caducidad;
		private bool _fecha_caducidadNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_ROLESRow_Base"/> class.
		/// </summary>
		public USUARIOS_ROLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USUARIOS_ROLESRow_Base original)
		{
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.ROL_ID != original.ROL_ID) return true;
			if (this.IsPERFIL_IDNull != original.IsPERFIL_IDNull) return true;
			if (!this.IsPERFIL_IDNull && !original.IsPERFIL_IDNull)
				if (this.PERFIL_ID != original.PERFIL_ID) return true;
			if (this.ID != original.ID) return true;
			if (this.IsFECHA_CADUCIDADNull != original.IsFECHA_CADUCIDADNull) return true;
			if (!this.IsFECHA_CADUCIDADNull && !original.IsFECHA_CADUCIDADNull)
				if (this.FECHA_CADUCIDAD != original.FECHA_CADUCIDAD) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO_ID</c> column value.</value>
		public decimal USUARIO_ID
		{
			get { return _usuario_id; }
			set { _usuario_id = value; }
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
		/// Gets or sets the <c>PERFIL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERFIL_ID</c> column value.</value>
		public decimal PERFIL_ID
		{
			get
			{
				if(IsPERFIL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _perfil_id;
			}
			set
			{
				_perfil_idNull = false;
				_perfil_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PERFIL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPERFIL_IDNull
		{
			get { return _perfil_idNull; }
			set { _perfil_idNull = value; }
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
		/// Gets or sets the <c>FECHA_CADUCIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA_CADUCIDAD</c> column value.</value>
		public System.DateTime FECHA_CADUCIDAD
		{
			get
			{
				if(IsFECHA_CADUCIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha_caducidad;
			}
			set
			{
				_fecha_caducidadNull = false;
				_fecha_caducidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA_CADUCIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHA_CADUCIDADNull
		{
			get { return _fecha_caducidadNull; }
			set { _fecha_caducidadNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@ROL_ID=");
			dynStr.Append(ROL_ID);
			dynStr.Append("@CBA@PERFIL_ID=");
			dynStr.Append(IsPERFIL_IDNull ? (object)"<NULL>" : PERFIL_ID);
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FECHA_CADUCIDAD=");
			dynStr.Append(IsFECHA_CADUCIDADNull ? (object)"<NULL>" : FECHA_CADUCIDAD);
			return dynStr.ToString();
		}
	} // End of USUARIOS_ROLESRow_Base class
} // End of namespace
