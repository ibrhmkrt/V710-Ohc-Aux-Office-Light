import QtQuick 2.0 
import "qrc:/" 
Item 
{ 
	objectName:"globalObject" 
	IGuiAlarmIndicator
	{
		id: q419430400
		objId: 419430400
		x: 257
		y: 5
		width: 37
		height: 53
		qm_BorderWidth: 1
		qm_ImageSource: "image://QSmartImageProvider/64#2#4#128#0#0"
		qm_Border.top: 2
		qm_Border.bottom: 2
		qm_Border.right: 2
		qm_Border.left: 2
		qm_FillColor: "#ff3d424d"
		z:105
		anchors.bottomMargin: 0
		anchors.topMargin: 1
		anchors.leftMargin: 1
		anchors.rightMargin: 1
		qm_AlarmTextPosX: 3
		qm_AlarmTextPosY: 37
		qm_AlarmTextWidth: 31
		qm_AlarmTextHeight: 14
		qm_TextColor: "#ffffffff"
		visible: false
		qm_GraphicImageID : 62
		Component.onCompleted:
		{
			proxy.initProxy(q419430400,419430400)
		}
	}
	IGuiDialogView
	{
		id: q520093696
		objId: 520093696
		x: 10
		y: 12
		width: 455
		height: 251
		z:35
		visible: false
		qm_BorderWidth: 1
		qm_RectangleBorder.color:"#ff13192c"
		qm_FillColor: "#ffff7f50"
		modalityWidth: 25
		modalityHeight: 21
		IGuiAlarmView
		{
			id: q402653186
			objId: 402653186
			x: 0
			y: 0
			width: 455
			height: 251
			qm_RectangleBorder.width:0
			qm_RectangleBorder.color:"#ff000000"
			qm_FillColor: "#fff7f3f7"
			IGuiListCtrl
			{
				id: qu402653186
				objectName: "qu402653186"
				x: 0
				y: 0
				width: 455
				height: 242
				qm_list.qm_linesPerRow: 2
				qm_list.qm_tableRowHeight: 18
				qm_list.qm_tableMarginLeft: 2
				qm_list.qm_tableMarginRight: 1
				qm_list.qm_tableMarginBottom: 1
				qm_list.qm_tableMarginTop: 1
				qm_list.qm_tableBackColor: "#ffffffff"
				qm_list.qm_tableSelectBackColor: "#ff94b6e7"
				qm_list.qm_tableAlternateBackColor: "#ffe7e7ef"
				qm_list.qm_tableTextColor: "#ff181c31"
				qm_list.qm_tableSelectTextColor: "#ffffffff"
				qm_list.qm_tableAlternateTextColor: "#ff181c31"
				qm_scrollCtrl: qus402653186

				qm_hasHeader: true
				qm_hasBorder: true
				qm_hasHorizontalScrollBar: true
				qm_hasVerticalScrollBar: true
				qm_list.qm_gridLineStyle: 0
				qm_list.qm_gridLineWidth: 0
				qm_list.qm_gridLineColor: "#ffffffff"
				qm_columnTypeList: [0]
				totalColumnWidth: 430
				qm_headerItem: qh402653186
				IGuiListHeader
				{
					id: qh402653186
					width: 430
					qm_listItem: qu402653186
					qm_columnWidthList: [430]
					color: "#ff000000"
					qm_tableHeaderTextColor: "#ffffffff"
					qm_tableHeaderValueVarTextAlignmentHorizontal: Text.AlignLeft
					qm_tableHeaderValueVarTextAlignmentVertical: Text.AlignVCenter
					qm_tableHeaderMarginLeft: 4
					qm_tableHeaderMarginRight: 2
					qm_tableHeaderMarginBottom: 2
					qm_tableHeaderMarginTop: 2
					qm_noOfColumns: 1
					qm_tableHeaderHeight: 18
					qm_leftImageID: 59
					qm_leftTileTop: 2
					qm_leftTileBottom: 2
					qm_leftTileRight: 2
					qm_leftTileLeft: 2
					qm_middleImageID: 60
					qm_middleTileTop: 2
					qm_middleTileBottom: 2
					qm_middleTileRight: 2
					qm_middleTileLeft: 2
					qm_rightImageID: 61
					qm_rightTileTop: 2
					qm_rightTileBottom: 2
					qm_rightTileRight: 2
					qm_rightTileLeft: 2
					radius: 0
				}
				IGuiListScrollBarCtrl
				{
					id: qus402653186

				}
			}
			Component.onCompleted:
			{
				proxy.initProxy(q402653186,402653186)
			}
		}
		Component.onCompleted:
		{
			proxy.initProxy(q520093696,520093696)
		}
	}
}
