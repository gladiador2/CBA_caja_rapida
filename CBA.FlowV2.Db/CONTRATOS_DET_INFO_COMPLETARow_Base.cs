// <fileinfo name="CONTRATOS_DET_INFO_COMPLETARow_Base.cs">
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
	/// The base class for <see cref="CONTRATOS_DET_INFO_COMPLETARow"/> that 
	/// represents a record in the <c>CONTRATOS_DET_INFO_COMPLETA</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTRATOS_DET_INFO_COMPLETARow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTRATOS_DET_INFO_COMPLETARow_Base
	{
		private decimal _id;
		private decimal _contrato_id;
		private string _plantilla_detalle_id;
		private string _plantilla_det_sql;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTRATOS_DET_INFO_COMPLETARow_Base"/> class.
		/// </summary>
		public CONTRATOS_DET_INFO_COMPLETARow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTRATOS_DET_INFO_COMPLETARow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CONTRATO_ID != original.CONTRATO_ID) return true;
			if (this.PLANTILLA_DETALLE_ID != original.PLANTILLA_DETALLE_ID) return true;
			if (this.PLANTILLA_DET_SQL != original.PLANTILLA_DET_SQL) return true;
			
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
		/// Gets or sets the <c>CONTRATO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CONTRATO_ID</c> column value.</value>
		public decimal CONTRATO_ID
		{
			get { return _contrato_id; }
			set { _contrato_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANTILLA_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANTILLA_DETALLE_ID</c> column value.</value>
		public string PLANTILLA_DETALLE_ID
		{
			get { return _plantilla_detalle_id; }
			set { _plantilla_detalle_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANTILLA_DET_SQL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANTILLA_DET_SQL</c> column value.</value>
		public string PLANTILLA_DET_SQL
		{
			get { return _plantilla_det_sql; }
			set { _plantilla_det_sql = value; }
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
			dynStr.Append("@CBA@CONTRATO_ID=");
			dynStr.Append(CONTRATO_ID);
			dynStr.Append("@CBA@PLANTILLA_DETALLE_ID=");
			dynStr.Append(PLANTILLA_DETALLE_ID);
			dynStr.Append("@CBA@PLANTILLA_DET_SQL=");
			dynStr.Append(PLANTILLA_DET_SQL);
			return dynStr.ToString();
		}
	} // End of CONTRATOS_DET_INFO_COMPLETARow_Base class
} // End of namespace
