<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" CaptionVisible="False" Caption="Attribute History" DataMember="AttributeVersions" runat="server" ID="frmAttributeHistory">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdAttributeHistory">
                    <Levels>
                        <px:PXGridLevel DataMember="AttributeVersions">
                            <!--#include file="~\Pages\AK\Includes\Grid_History.inc"-->
                        </px:PXGridLevel>
                    </Levels>
                    <AutoSize Enabled="True" Container="Parent"></AutoSize>
                    <AutoSize MinHeight="200"></AutoSize>
                    <AutoSize MinWidth="200"></AutoSize>
                    <AutoCallBack Target="frmCurrentAttributeVersion" ActiveBehavior="True" Command="Refresh">
                        <Behavior RepaintControlsIDs="frmCurrentAttributeVersion"></Behavior>
                    </AutoCallBack>
                    <AutoCallBack Target="frmObjectVersions"></AutoCallBack>
                    <AutoCallBack ActiveBehavior="True"></AutoCallBack>
                    <AutoCallBack Command="Refresh"></AutoCallBack>
                    <CallbackCommands>
                        <Refresh SelectControlsIDs="txtAttributeVersion" RepaintControlsIDs="txtAttributeVersion"></Refresh>
                    </CallbackCommands>
                    <ActionBar ActionsVisible="True">
                        <CustomItems>
                            <px:PXToolBarButton DependOnGrid="" NavigateUrl="amazon.com" Text="Compare"></px:PXToolBarButton>
                        </CustomItems>
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                            <Delete Enabled="False"></Delete>
                        </Actions>
                    </ActionBar>
                </px:PXGrid>
            </Template>
            <CallbackCommands>
                <Refresh RepaintControlsIDs="grdAttributeHistory,txtAttributeVersion"></Refresh>
            </CallbackCommands>
        </px:PXFormView>
    </Template>
</px:PXTabItem>