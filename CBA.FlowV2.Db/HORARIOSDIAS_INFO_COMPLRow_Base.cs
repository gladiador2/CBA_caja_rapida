// <fileinfo name="HORARIOSDIAS_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="HORARIOSDIAS_INFO_COMPLRow"/> that 
	/// represents a record in the <c>HORARIOSDIAS_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="HORARIOSDIAS_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class HORARIOSDIAS_INFO_COMPLRow_Base
	{
		private decimal _horarirodiaid;
		private decimal _horario_id;
		private decimal _diaid;
		private string _nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="HORARIOSDIAS_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public HORARIOSDIAS_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(HORARIOSDIAS_INFO_COMPLRow_Base original)
		{
			if (this.HORARIRODIAID != original.HORARIRODIAID) return true;
			if (this.HORARIO_ID != original.HORARIO_ID) return true;
			if (this.DIAID != original.DIAID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>HORARIRODIAID</c> column value.
		/// </summary>
		/// <value>The <c>HORARIRODIAID</c> column value.</value>
		public decimal HORARIRODIAID
		{
			get { return _horarirodiaid; }
			set { _horarirodiaid = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>HORARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>HORARIO_ID</c> column value.</value>
		public decimal HORARIO_ID
		{
			get { return _horario_id; }
			set { _horario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAID</c> column value.
		/// </summary>
		/// <value>The <c>DIAID</c> column value.</value>
		public decimal DIAID
		{
			get { return _diaid; }
			set { _diaid = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@HORARIRODIAID=");
			dynStr.Append(HORARIRODIAID);
			dynStr.Append("@CBA@HORARIO_ID=");
			dynStr.Append(HORARIO_ID);
			dynStr.Append("@CBA@DIAID=");
			dynStr.Append(DIAID);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			return dynStr.ToString();
		}
	} // End of HORARIOSDIAS_INFO_COMPLRow_Base class
} // End of namespace
