<px:PXTabItem Text="History">
    <Template>
        <px:PXFormView Width="500" CaptionVisible="False" Caption="Attribute History" DataMember="AttributeVersions" runat="server" ID="frmAttributeHistory">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdAttributeHistory">
                    <Levels>
                        <px:PXGridLevel DataMember="AttributeVersions">
                            <Columns>
                                <px:PXGridColumn Type="CheckBox" DataField="Selected" Width="60"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Version" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="ActionName" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Description" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="ControlType" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="CreatedDateTime" Width="90"></px:PXGridColumn>
                            </Columns>
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