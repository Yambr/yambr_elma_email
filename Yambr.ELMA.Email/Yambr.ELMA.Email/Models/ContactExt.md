<?xml version="1.0" encoding="utf-8"?>
<Entity xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Uid>fc36295d-1bc9-4e0b-b219-c9728c9f6117</Uid>
  <Name>ContactExt</Name>
  <DisplayName>ContactExt</DisplayName>
  <Namespace>Yambr.ELMA.Email.Models</Namespace>
  <BaseClassUid>a9b1bc6a-3286-4264-81aa-02f6df73c080</BaseClassUid>
  <FormsScheme>FormConstructor</FormsScheme>
  <FormTransformations>
    <FormViewItemTransformation>
      <Uid>31ec86ee-5424-4c1a-a5ba-21a6fb29ca53</Uid>
      <FormName>Display</FormName>
      <Items>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>69a7629a-5b49-46d7-af60-7dd8b35d7029</Uid>
          <MoveItemUid>3449dd67-afae-4db9-9fec-33fe8b25ce58</MoveItemUid>
          <BeforeItem>c395ec3b-4cf4-4482-b32e-5dd8141c72fc</BeforeItem>
          <AfterItem>43b10778-2c94-4c41-aa61-8557d718b380</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>69a7629a-5b49-46d7-af60-7dd8b35d7029</Uid>
          <MoveItemUid>c395ec3b-4cf4-4482-b32e-5dd8141c72fc</MoveItemUid>
          <BeforeItem>7b3ca8d7-641c-40cd-869b-0a80c842dd25</BeforeItem>
          <AfterItem>3449dd67-afae-4db9-9fec-33fe8b25ce58</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationMove">
          <Uid>69a7629a-5b49-46d7-af60-7dd8b35d7029</Uid>
          <MoveItemUid>7b3ca8d7-641c-40cd-869b-0a80c842dd25</MoveItemUid>
          <AfterItem>c395ec3b-4cf4-4482-b32e-5dd8141c72fc</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationAdd">
          <Uid>69a7629a-5b49-46d7-af60-7dd8b35d7029</Uid>
          <Item xsi:type="TabViewItem">
            <Name>EmailMessagesTab</Name>
            <Uid>7efc4b02-21e7-448d-a4b1-5bb9d9a6b402</Uid>
            <Caption>История переписки</Caption>
          </Item>
          <BeforeItem>3449dd67-afae-4db9-9fec-33fe8b25ce58</BeforeItem>
          <AfterItem>43b10778-2c94-4c41-aa61-8557d718b380</AfterItem>
        </ViewItemTransformation>
        <ViewItemTransformation xsi:type="ViewItemTransformationAdd">
          <Uid>7efc4b02-21e7-448d-a4b1-5bb9d9a6b402</Uid>
          <Item xsi:type="ExtensionZoneViewItem">
            <Name>ExtensionZone2</Name>
            <Uid>75a72ed6-6b29-4b7b-8759-1f82728f5383</Uid>
            <ZoneId>Contact.EmailMessages</ZoneId>
          </Item>
        </ViewItemTransformation>
      </Items>
    </FormViewItemTransformation>
  </FormTransformations>
  <TableViews>
    <TableView>
      <Uid>b47df5a3-2b07-4a3e-9ae5-562e660503ca</Uid>
      <ViewType>List</ViewType>
    </TableView>
  </TableViews>
  <Type>InterfaceExtension</Type>
  <ImplementationUid>05d04649-368b-492f-a652-6e4bf4d84dd9</ImplementationUid>
  <IdTypeUid>d90a59af-7e47-48c5-8c4c-dad04834e6e3</IdTypeUid>
  <TableName>ContactExt</TableName>
  <IsSoftDeletable>true</IsSoftDeletable>
  <Actions />
</Entity>