// <fileinfo name="USUARIOS_SUCURSALES_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="USUARIOS_SUCURSALES_INF_COMPRow"/> that 
	/// represents a record in the <c>USUARIOS_SUCURSALES_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USUARIOS_SUCURSALES_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USUARIOS_SUCURSALES_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _region_id;
		private bool _region_idNull = true;
		private decimal _usuario_id;
		private decimal _sucursal_id;
		private string _usuario;
		private string _nombre_region;
		private string _abreviatura_region;
		private string _nombre_sucursal;
		private string _abreviatura_sucursal;

		/// <summary>
		/// Initializes a new instance of the <see cref="USUARIOS_SUCURSALES_INF_COMPRow_Base"/> class.
		/// </summary>
		public USUARIOS_SUCURSALES_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USUARIOS_SUCURSALES_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsREGION_IDNull != original.IsREGION_IDNull) return true;
			if (!this.IsREGION_IDNull && !original.IsREGION_IDNull)
				if (this.REGION_ID != original.REGION_ID) return true;
			if (this.USUARIO_ID != original.USUARIO_ID) return true;
			if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			if (this.USUARIO != original.USUARIO) return true;
			if (this.NOMBRE_REGION != original.NOMBRE_REGION) return true;
			if (this.ABREVIATURA_REGION != original.ABREVIATURA_REGION) return true;
			if (this.NOMBRE_SUCURSAL != original.NOMBRE_SUCURSAL) return true;
			if (this.ABREVIATURA_SUCURSAL != original.ABREVIATURA_SUCURSAL) return true;
			
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
		/// Gets or sets the <c>REGION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>REGION_ID</c> column value.</value>
		public decimal REGION_ID
		{
			get
			{
				if(IsREGION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _region_id;
			}
			set
			{
				_region_idNull = false;
				_region_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="REGION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsREGION_IDNull
		{
			get { return _region_idNull; }
			set { _region_idNull = value; }
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get { return _sucursal_id; }
			set { _sucursal_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>USUARIO</c> column value.
		/// </summary>
		/// <value>The <c>USUARIO</c> column value.</value>
		public string USUARIO
		{
			get { return _usuario; }
			set { _usuario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_REGION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_REGION</c> column value.</value>
		public string NOMBRE_REGION
		{
			get { return _nombre_region; }
			set { _nombre_region = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABREVIATURA_REGION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ABREVIATURA_REGION</c> column value.</value>
		public string ABREVIATURA_REGION
		{
			get { return _abreviatura_region; }
			set { _abreviatura_region = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_SUCURSAL</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_SUCURSAL</c> column value.</value>
		public string NOMBRE_SUCURSAL
		{
			get { return _nombre_sucursal; }
			set { _nombre_sucursal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ABREVIATURA_SUCURSAL</c> column value.
		/// </summary>
		/// <value>The <c>ABREVIATURA_SUCURSAL</c> column value.</value>
		public string ABREVIATURA_SUCURSAL
		{
			get { return _abreviatura_sucursal; }
			set { _abreviatura_sucursal = value; }
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
			dynStr.Append("@CBA@REGION_ID=");
			dynStr.Append(IsREGION_IDNull ? (object)"<NULL>" : REGION_ID);
			dynStr.Append("@CBA@USUARIO_ID=");
			dynStr.Append(USUARIO_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(SUCURSAL_ID);
			dynStr.Append("@CBA@USUARIO=");
			dynStr.Append(USUARIO);
			dynStr.Append("@CBA@NOMBRE_REGION=");
			dynStr.Append(NOMBRE_REGION);
			dynStr.Append("@CBA@ABREVIATURA_REGION=");
			dynStr.Append(ABREVIATURA_REGION);
			dynStr.Append("@CBA@NOMBRE_SUCURSAL=");
			dynStr.Append(NOMBRE_SUCURSAL);
			dynStr.Append("@CBA@ABREVIATURA_SUCURSAL=");
			dynStr.Append(ABREVIATURA_SUCURSAL);
			return dynStr.ToString();
		}
	} // End of USUARIOS_SUCURSALES_INF_COMPRow_Base class
} // End of namespace
