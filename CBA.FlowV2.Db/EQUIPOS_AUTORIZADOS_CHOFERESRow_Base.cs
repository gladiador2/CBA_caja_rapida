// <fileinfo name="EQUIPOS_AUTORIZADOS_CHOFERESRow_Base.cs">
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
	/// The base class for <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/> that 
	/// represents a record in the <c>EQUIPOS_AUTORIZADOS_CHOFERES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class EQUIPOS_AUTORIZADOS_CHOFERESRow_Base
	{
		private decimal _id;
		private decimal _equipo_autorizado_id;
		private bool _equipo_autorizado_idNull = true;
		private string _numero_documento;
		private string _nombre_chofer;

		/// <summary>
		/// Initializes a new instance of the <see cref="EQUIPOS_AUTORIZADOS_CHOFERESRow_Base"/> class.
		/// </summary>
		public EQUIPOS_AUTORIZADOS_CHOFERESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(EQUIPOS_AUTORIZADOS_CHOFERESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsEQUIPO_AUTORIZADO_IDNull != original.IsEQUIPO_AUTORIZADO_IDNull) return true;
			if (!this.IsEQUIPO_AUTORIZADO_IDNull && !original.IsEQUIPO_AUTORIZADO_IDNull)
				if (this.EQUIPO_AUTORIZADO_ID != original.EQUIPO_AUTORIZADO_ID) return true;
			if (this.NUMERO_DOCUMENTO != original.NUMERO_DOCUMENTO) return true;
			if (this.NOMBRE_CHOFER != original.NOMBRE_CHOFER) return true;
			
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
		/// Gets or sets the <c>EQUIPO_AUTORIZADO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EQUIPO_AUTORIZADO_ID</c> column value.</value>
		public decimal EQUIPO_AUTORIZADO_ID
		{
			get
			{
				if(IsEQUIPO_AUTORIZADO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _equipo_autorizado_id;
			}
			set
			{
				_equipo_autorizado_idNull = false;
				_equipo_autorizado_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EQUIPO_AUTORIZADO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEQUIPO_AUTORIZADO_IDNull
		{
			get { return _equipo_autorizado_idNull; }
			set { _equipo_autorizado_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NUMERO_DOCUMENTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NUMERO_DOCUMENTO</c> column value.</value>
		public string NUMERO_DOCUMENTO
		{
			get { return _numero_documento; }
			set { _numero_documento = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_CHOFER</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_CHOFER</c> column value.</value>
		public string NOMBRE_CHOFER
		{
			get { return _nombre_chofer; }
			set { _nombre_chofer = value; }
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
			dynStr.Append("@CBA@EQUIPO_AUTORIZADO_ID=");
			dynStr.Append(IsEQUIPO_AUTORIZADO_IDNull ? (object)"<NULL>" : EQUIPO_AUTORIZADO_ID);
			dynStr.Append("@CBA@NUMERO_DOCUMENTO=");
			dynStr.Append(NUMERO_DOCUMENTO);
			dynStr.Append("@CBA@NOMBRE_CHOFER=");
			dynStr.Append(NOMBRE_CHOFER);
			return dynStr.ToString();
		}
	} // End of EQUIPOS_AUTORIZADOS_CHOFERESRow_Base class
} // End of namespace
