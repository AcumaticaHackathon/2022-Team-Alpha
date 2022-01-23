<px:PXTabItem Text="Results">
    <Template>
        <px:PXFormView Width="500" DataMember="GIResults" Height="" runat="server" ID="frmGIResults" Caption="Results" CaptionVisible="False">
            <Template>
                <px:PXGrid FilesIndicator="False" NoteIndicator="False" SyncPosition="True" SkinID="Details" Height="300" runat="server" ID="grdGIResults">
                    <Levels>
                        <px:PXGridLevel DataMember="GIResults">
                            <Columns>
                                <px:PXGridColumn DataField="ObjectName" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Field" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="SchemaField" Width="280"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Caption" Width="250"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar ActionsVisible="True">
                        <Actions>
                            <AddNew Enabled="False"></AddNew>
                        </Actions>
                        <Actions>
                            <Delete Enabled="False"></Delete>
                        </Actions>
                        <Actions>
                            <EditRecord Enabled="False"></EditRecord>
                        </Actions>
                        <Actions>
                            <Save Enabled="False"></Save>
                        </Actions>
                        <CustomItems>
                            <px:PXToolBarButton Text="Results History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>