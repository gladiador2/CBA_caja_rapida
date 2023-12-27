// <fileinfo name="USO_DE_INSUMOS_DET_CTBRow_Base.cs">
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
	/// The base class for <see cref="USO_DE_INSUMOS_DET_CTBRow"/> that 
	/// represents a record in the <c>USO_DE_INSUMOS_DET_CTB</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="USO_DE_INSUMOS_DET_CTBRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class USO_DE_INSUMOS_DET_CTBRow_Base
	{
		private decimal _id;
		private decimal _uso_de_insumos_det_id;
		private bool _uso_de_insumos_det_idNull = true;
		private decimal _ctb_cuenta_id;
		private bool _ctb_cuenta_idNull = true;
		private decimal _porcentaje;
		private bool _porcentajeNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="USO_DE_INSUMOS_DET_CTBRow_Base"/> class.
		/// </summary>
		public USO_DE_INSUMOS_DET_CTBRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(USO_DE_INSUMOS_DET_CTBRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsUSO_DE_INSUMOS_DET_IDNull != original.IsUSO_DE_INSUMOS_DET_IDNull) return true;
			if (!this.IsUSO_DE_INSUMOS_DET_IDNull && !original.IsUSO_DE_INSUMOS_DET_IDNull)
				if (this.USO_DE_INSUMOS_DET_ID != original.USO_DE_INSUMOS_DET_ID) return true;
			if (this.IsCTB_CUENTA_IDNull != original.IsCTB_CUENTA_IDNull) return true;
			if (!this.IsCTB_CUENTA_IDNull && !original.IsCTB_CUENTA_IDNull)
				if (this.CTB_CUENTA_ID != original.CTB_CUENTA_ID) return true;
			if (this.IsPORCENTAJENull != original.IsPORCENTAJENull) return true;
			if (!this.IsPORCENTAJENull && !original.IsPORCENTAJENull)
				if (this.PORCENTAJE != original.PORCENTAJE) return true;
			
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
		/// Gets or sets the <c>USO_DE_INSUMOS_DET_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>USO_DE_INSUMOS_DET_ID</c> column value.</value>
		public decimal USO_DE_INSUMOS_DET_ID
		{
			get
			{
				if(IsUSO_DE_INSUMOS_DET_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _uso_de_insumos_det_id;
			}
			set
			{
				_uso_de_insumos_det_idNull = false;
				_uso_de_insumos_det_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="USO_DE_INSUMOS_DET_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsUSO_DE_INSUMOS_DET_IDNull
		{
			get { return _uso_de_insumos_det_idNull; }
			set { _uso_de_insumos_det_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_CUENTA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CTB_CUENTA_ID</c> column value.</value>
		public decimal CTB_CUENTA_ID
		{
			get
			{
				if(IsCTB_CUENTA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _ctb_cuenta_id;
			}
			set
			{
				_ctb_cuenta_idNull = false;
				_ctb_cuenta_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CTB_CUENTA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCTB_CUENTA_IDNull
		{
			get { return _ctb_cuenta_idNull; }
			set { _ctb_cuenta_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get
			{
				if(IsPORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje;
			}
			set
			{
				_porcentajeNull = false;
				_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJENull
		{
			get { return _porcentajeNull; }
			set { _porcentajeNull = value; }
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
			dynStr.Append("@CBA@USO_DE_INSUMOS_DET_ID=");
			dynStr.Append(IsUSO_DE_INSUMOS_DET_IDNull ? (object)"<NULL>" : USO_DE_INSUMOS_DET_ID);
			dynStr.Append("@CBA@CTB_CUENTA_ID=");
			dynStr.Append(IsCTB_CUENTA_IDNull ? (object)"<NULL>" : CTB_CUENTA_ID);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(IsPORCENTAJENull ? (object)"<NULL>" : PORCENTAJE);
			return dynStr.ToString();
		}
	} // End of USO_DE_INSUMOS_DET_CTBRow_Base class
} // End of namespace
