<px:PXTabItem Text="Ons">
    <Template>
        <px:PXFormView FilesIndicator="False" NoteIndicator="False" SyncPosition="True" Width="500" DataMember="GIOns" Caption="Ons" CaptionVisible="False" runat="server" ID="frmGIOns">
            <Template>
                <px:PXGrid SkinID="Details" Height="300" runat="server" ID="grdGIOns">
                    <Levels>
                        <px:PXGridLevel DataMember="GIOns">
                            <Columns>
                                <px:PXGridColumn DataField="ParentField" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="Condition" Width="70"></px:PXGridColumn>
                                <px:PXGridColumn DataField="ChildField" Width="70"></px:PXGridColumn>
                            </Columns>
                        </px:PXGridLevel>
                    </Levels>
                    <ActionBar>
                        <CustomItems>
                            <px:PXToolBarButton Text="On History"></px:PXToolBarButton>
                        </CustomItems>
                    </ActionBar>
                </px:PXGrid>
            </Template>
        </px:PXFormView>
    </Template>
</px:PXTabItem>